        public class IosWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>
        {
            const string HtmlCode = "document.body.outerHTML";
    
            protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
            {
                base.OnElementChanged(e);
                if (Control == null)
                {
                    WKWebView wKWebView = new WKWebView(Frame, new WKWebViewConfiguration());
                    wKWebView.NavigationDelegate = new WebViewDelate();
                    SetNativeControl(wKWebView);
                }
                if (e.NewElement != null)
                {
                    NSUrlRequest nSUrlRequest = new NSUrlRequest(new NSUrl(hybridWebView.Uri.ToString()));
                    Control.LoadRequest(nSUrlRequest);
                }
            }
    
            class WebViewDelate : WKNavigationDelegate
            {
                public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
                {
                    WKJavascriptEvaluationResult handler = (NSObject result, NSError error) => {
                        if (error != null)
                        {
                            Console.WriteLine(result.ToString());
                        }
                    };
                    webView.EvaluateJavaScript(HtmlCode, handler);
                }
            }
        }
