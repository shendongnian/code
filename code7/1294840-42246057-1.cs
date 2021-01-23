    public class SimpleLinkLabel : Label
	{
		public SimpleLinkLabel(Uri uri, string labelText = null)
		{
			Text = labelText ?? uri.ToString();
			GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => Device.OpenUri(uri)) });
		}
	}
