	/// <summary>
	///		Intent: Add this Attached Property to any XAML element, to allow you to click and drag the entire window.
    ///	    Essentially, it searches up the visual tree to find the first parent window, then calls ".DragMove()" on it. Once the drag finishes, it pushes
    ///     the window back onto the screen if part or all of it wasn't visible.
	/// </summary>
	public class EnableDragAttachedProperty
	{
		public static readonly DependencyProperty EnableDragProperty = DependencyProperty.RegisterAttached(
			"EnableDrag",
			typeof(bool),
			typeof(EnableDragAttachedProperty),
			new PropertyMetadata(default(bool), OnLoaded));
		private static void OnLoaded(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			try
			{
				var uiElement = dependencyObject as UIElement;
				if (uiElement == null || (dependencyPropertyChangedEventArgs.NewValue is bool) == false)
				{
					return;
				}
				if ((bool)dependencyPropertyChangedEventArgs.NewValue == true)
				{
					uiElement.MouseMove += UIElement_OnMouseMove;
				}
				else
				{
					uiElement.MouseMove -= UIElement_OnMouseMove;
				}
			}
			catch (Exception ex)
			{
                 // Log exception here.
			}
		}
		/// <summary>
		///		Intent: Fetches the parent window, so we can call "DragMove()"on it. Caches the results in a dictionary,
		///	    so we can apply this same property to multiple XAML elements.
		/// </summary>
		private static void UIElement_OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
		{
			try
			{
				var uiElement = sender as UIElement;
				if (uiElement != null)
				{
					Window window = GetParentWindow(uiElement);
					if (mouseEventArgs.LeftButton == MouseButtonState.Pressed)
					{
						// DragMove is a synchronous call: once it completes, the drag is finished and the left mouse
                        // button has been released.
						window?.DragMove();
                        // See answer in section 'Additional Links' below in the SO answer.
                    //HideAndShowWindowHelper.ShiftWindowIntoForeground(window);
						// When the use has finished the drag and released the mouse button, we shift the window back
						// onto the screen, it it ended up partially off the screen.
						ShiftWindowOntoScreenHelper.ShiftWindowOntoScreen(window);
					}
				}
			}
			catch (Exception ex)
			{
				_log.Warn($"Exception in {nameof(UIElement_OnMouseMove)}. " +
				          $"This means that we cannot shift and drag the Toast Notification window. " +
				          $"To fix, correct C# code.", ex);
			}
		}
		public static void SetEnableDrag(DependencyObject element, bool value)
		{
			element.SetValue(EnableDragProperty, value);
		}
		public static bool GetEnableDrag(DependencyObject element)
		{
			return (bool)element.GetValue(EnableDragProperty);
		}
		#region GetParentWindow
		private static readonly Dictionary<UIElement, Window> _parentWindow = new Dictionary<UIElement, Window>();
		private static readonly object _parentWindowLock = new object();
		/// <summary>
		///		Intent: Given any UIElement, searches up the visual tree to find the parent Window.
		/// </summary>
		private static Window GetParentWindow(UIElement uiElement)
		{
			bool ifAlreadyFound;
			lock (_parentWindowLock)
			{
				ifAlreadyFound = _parentWindow.ContainsKey(uiElement) == true;
			}
			if (ifAlreadyFound == false)
			{
				DependencyObject parent = uiElement;
				int avoidInfiniteLoop = 0;
				// Search up the visual tree to find the first parent window.
				while ((parent is Window) == false)
				{
					parent = VisualTreeHelper.GetParent(parent);
					avoidInfiniteLoop++;
					if (avoidInfiniteLoop == 1000)
					{
						// Something is wrong - we could not find the parent window.
						return null;
					}
				}
				lock (_parentWindowLock)
				{
					_parentWindow[uiElement] = parent as Window;
				}
			}
			lock(_parentWindowLock)
			{
				return _parentWindow[uiElement];
			}
		}
		#endregion
	}
