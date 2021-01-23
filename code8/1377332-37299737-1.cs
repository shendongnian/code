    public class CustomWebViewRenderer : WebViewRenderer {
        #region Properties
        public CustomWebView CustomWebViewItem { get { return Element as CustomWebView; } }
        #endregion
        protected override void OnElementChanged(VisualElementChangedEventArgs e) {
            base.OnElementChanged(e);
            if(e.OldElement == null) {
                Delegate = new CustomWebViewDelegate(); //Assigning the delegate
            }
        }
    }
    internal class CustomWebViewDelegate : UIWebViewDelegate {
        public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType) {
            if(navigationType == UIWebViewNavigationType.LinkClicked) {
                //To prevent navigation when a link is click, return false
                return false;
            }
            return true;
        }
    }
