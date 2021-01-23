	public class LinkLabel : StackLayout
	{
		private SimpleLinkLabel label;
		public LinkLabel(Uri uri, string labelText = null, bool underlined = true)
		{
			// Remove bottom padding
			Padding = new Thickness(Padding.Left, Padding.Top, Padding.Right, 0);
			VerticalOptions = LayoutOptions.Center;
			Children.Add(label = new SimpleLinkLabel(uri, labelText));
			if (underlined)
				Children.Add(new BoxView { BackgroundColor = Color.Blue, HeightRequest = 1, Margin = new Thickness(0, -8, 0, 0) });
		}
		public TextAlignment HorizontalTextAlignment { get { return label.HorizontalTextAlignment; } set { label.HorizontalTextAlignment = value; } }
	}
