    public class HyperlinkButton : Button
    {
        public string NavigateUri { get; set; }
        protected override void OnClick(EventArgs e)
        { 
            if (NavigateUri != null)
            {
                var uri = new Uri(NavigateUri, UriKind.Relative);
                NavigationService.Navigate(uri);
            }
        }
    }
