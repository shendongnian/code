    string htmlText = MyItem.Article.ToString().Replace(@"\", string.Empty);
    var browser = new WebView ();
    var html = new HtmlWebViewSource {
      Html = htmlText
    };
    browser.Source = html;
Because Xamarin.Forms.HtmlWebViewSource.HTML expect a pure HTML. Using this you can create a Xamarin.Forms user control with the help of this article http://blog.falafel.com/creating-reusable-xaml-user-controls-xamarin-forms/ Cheers..!
