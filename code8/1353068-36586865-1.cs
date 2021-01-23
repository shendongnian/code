    public class UniversalView : UIView, IWKScriptMessageHandler
    {
        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            var msg = message.Body.ToString();
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
