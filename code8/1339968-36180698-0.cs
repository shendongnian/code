	public static class ComboBoxHelper
	{
		public static readonly DependencyProperty EditBackgroundProperty = DependencyProperty.RegisterAttached(
			"EditBackground", typeof (Brush), typeof (ComboBoxHelper), new PropertyMetadata(default(Brush), EditBackgroundChanged));
		private static void EditBackgroundChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			var combo = dependencyObject as ComboBox;
			if (combo != null)
			{
				if (!combo.IsLoaded)
				{
					RoutedEventHandler comboOnLoaded = null;
					comboOnLoaded = delegate(object sender, RoutedEventArgs eventArgs)
					{
						EditBackgroundChanged(dependencyObject, args);
						combo.Loaded -= comboOnLoaded;
					};
					combo.Loaded += comboOnLoaded;
					return;
				}
				var part = combo.Template.FindName("PART_EditableTextBox", combo);
				var tb = part as TextBox;
				if (tb != null)
				{
					var parent = tb.Parent as Border;
					if (parent != null)
					{
						parent.Background = (Brush)args.NewValue;
					}
				}
			}
		}
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static void SetEditBackground(DependencyObject element, Brush value)
		{
			element.SetValue(EditBackgroundProperty, value);
		}
		[AttachedPropertyBrowsableForType(typeof(ComboBox))]
		public static Brush GetEditBackground(DependencyObject element)
		{
			return (Brush) element.GetValue(EditBackgroundProperty);
		}
	}
