    public class HighlightHelper : DependencyObject
	{
		public static Brush GetHighlightBrush(DependencyObject obj)
		{
			return (Brush)obj.GetValue(HighlightBrushProperty);
		}
		public static void SetHighlightBrush(DependencyObject obj, Brush value)
		{
			obj.SetValue(HighlightBrushProperty, value);
		}
		public static readonly DependencyProperty HighlightBrushProperty =
			DependencyProperty.RegisterAttached("HighlightBrush", typeof(Brush), typeof(HighlightHelper), new PropertyMetadata(Brushes.Black));
		public static string GetHighlightWord(UIElement element)
		{
			return (string)element.GetValue(HighlightWordProperty);
		}
		public static void SetHighlightWord(UIElement element, string value)
		{
			element.SetValue(HighlightWordProperty, value);
		}
		public static readonly DependencyProperty HighlightWordProperty =
			DependencyProperty.RegisterAttached("HighlightWord", typeof(string), typeof(HighlightHelper), new PropertyMetadata(OnHighlightWordChanged));
		private static void OnHighlightWordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			TextBlock textBlock = (TextBlock)d;
			string text = textBlock.Text;
			string highlightWord = (string)e.NewValue;
			textBlock.Inlines.Clear();
			string[] tokens = Regex.Split(text, "(" + Regex.Escape(highlightWord) + ")");
			foreach (string token in tokens)
			{
				Run run = new Run { Text = token };
				if (token.Equals(highlightWord))
				{
					Brush highlightBrush = (Brush)textBlock.GetValue(HighlightBrushProperty);
					run.Foreground = highlightBrush;
				}
				textBlock.Inlines.Add(run);
			}
		}
	}
