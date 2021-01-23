    Public class SitePage : ContentPage
    {
    
        public SitePage(string text)
        {
           var entry = new Entry();
           entry.Text = text;
           this.Content = entry;
        }
    }
