	public static class GetValueBasedOnContentSelectorBehavior
	{
		private static readonly Dictionary<Content, TextBox> Map = new Dictionary<Content, TextBox>();
		public static readonly DependencyProperty ContentProperty = DependencyProperty.RegisterAttached(
			"Content", typeof(Content), typeof(GetValueBasedOnContentSelectorBehavior), new PropertyMetadata(default(Content), OnContentChanged));
		private static void OnContentChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
		{
			var textBox = dependencyObject as TextBox;
            if (textBox == null) return;
			var oldContent = dependencyPropertyChangedEventArgs.OldValue as Content;
			if (oldContent != null && Map.Remove(oldContent))
				oldContent.PropertyChanged -= ContentOnPropertyChanged;
			var newContent = dependencyPropertyChangedEventArgs.NewValue as Content;
			if (newContent != null)
			{
				newContent.PropertyChanged += ContentOnPropertyChanged;
				Map.Add(newContent, textBox);
				RedoBinding(textBox, newContent);
			}
		}
		private static void ContentOnPropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			var content = sender as Content;
			if (content == null) return;
			TextBox textBox;
			if (args.PropertyName == "Selector" && Map.TryGetValue(content, out textBox))
				RedoBinding(textBox, content);
		}
		private static void RedoBinding(TextBox textBox, Content content)
		{
			textBox.SetBinding(TextBox.TextProperty,
				new Binding { Source = content, Path = new PropertyPath("Value" + content.Selector) });
		}
		public static Content GetContent(TextBox txtBox)
		{
			return (Content)txtBox.GetValue(ContentProperty);
		}
		public static void SetContent(TextBox txtBox, Content value)
		{
			txtBox.SetValue(ContentProperty, value);
		}
	}
