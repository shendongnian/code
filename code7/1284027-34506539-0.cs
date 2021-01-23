    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Xamarin;
    using Xamarin.Forms;
    
    namespace mynamespace
    {
        public class WebsitePage : ContentPage
        {
            public WebsitePage(string url)
            {
                Label lbl_header = new Label
                {
                    Text = "WebView",
                    HorizontalOptions = LayoutOptions.Center
                };
                WebView webview = new WebView
                {
                    Source = url,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                this.Content = new StackLayout
                {
                    Children = {
                         webview
                    }
                };
            }
        }
    }
