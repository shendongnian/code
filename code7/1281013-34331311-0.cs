    // ... Other code
    public WebPage()
    {
      webView = new WebView 
      {
         Source = "https://www.google.com",
         VerticalOptions = LayoutOptions.FillAndExpand,
         HorizontalOptions = LayoutOptions.FillAndExpand
      };
      // toolbar
      ToolbarItems.Add(new ToolbarItem("Back", null, () =>
      {
         webView.GoBack();
      }));
      Content = new StackLayout
      {
         Children = { webView }
      };
    }
    // ... Other code
