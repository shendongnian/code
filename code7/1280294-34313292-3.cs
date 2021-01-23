    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using System.Text;
    
    using Xamarin.Forms;
    
    namespace DisplayWebPage
    {
        public class WebPage : ContentPage
        {
            private WebView _webView;
            public WebPage()
            {
               // Assign a WebView to a global variable
                _webView = new WebView
                        {
                            Source = "http://www.google.com"
                        };
                // Create toolbar items here
                ToolbarItems.Add(new ToolbarItem("Back", "BackIcon.png", () => { _webview.GoBack(); }));
                Content = new StackLayout
                {
                    Children = { _webView}
                };
            }
        }
    }
