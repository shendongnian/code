    // a popupWindowAction that allows the DI to compose its view
	public class ComposablePopupWindowAction : PopupWindowAction
	{
		public static readonly DependencyProperty WindowContentTypeProperty =
			DependencyProperty.Register(
				"WindowContentType",
				typeof(Type),
				typeof(ComposablePopupWindowAction),
				new PropertyMetadata(null),
                v => {
					Type type = v as Type;
					Type frameworkElementType = typeof(FrameworkElement);
					// either this is not specified, or if it is then it needs to be a FrameworkElement
					return (v == null) || type.IsSubclassOf(frameworkElementType) || (type == frameworkElementType);
				}
			);
		public Type WindowContentType
		{
			get { return (Type)GetValue(WindowContentTypeProperty); }
			set { SetValue(WindowContentTypeProperty, value); }
		}
		protected override void Invoke(object parameter)
		{
			ConfigureWindowContent();
			base.Invoke(parameter);
		}
		protected void ConfigureWindowContent()
		{
			// configure the windowContent if not specified, but a type was
			if ((this.WindowContentType != null) && (this.WindowContent == null))
			{
				// this doesn't appear to be supported in Unity so might need slightly different logic here?
				var view = ServiceLocator.Current.TryResolve(this.WindowContentType);
				// if can't get thedesired type then base will use the notification
				if ((view != null) && (view.GetType() == this.WindowContentType))
				{
					this.WindowContent = view as FrameworkElement;
				}
			}
		}
	}
