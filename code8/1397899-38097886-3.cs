    public class ExtendedWebBrowser : System.Windows.Forms.WebBrowser
    {
        public ExtendedWebBrowser()
        {
            // Ensure that ScriptErrorsSuppressed is set to false.
            this.ScriptErrorsSuppressed = true;
            this.ProgressChanged += ExtendedWebBrowser_ProgressChanged;
        }
        private void ExtendedWebBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            // InjectAlertBlocker();
            string alertBlocker = @"window.alert = function () { }; 
                            window.print = function () { }; 
                            window.open = function () { }; 
                            window.onunload = function () { }; 
                            window.onbeforeunload = function () { };";
            var webBrowser = sender as WebBrowser;
            webBrowser?.Document?.InvokeScript("execScript", new Object[] { alertBlocker, "JavaScript" });
            this.Document?.InvokeScript("execScript", new Object[] { alertBlocker, "JavaScript" });
        }
        public void NavigationWaitToComplete(string url)
        {
            bool complete = false;
            NavigationAsync(url).ContinueWith((t) => complete = true);
            while (!complete)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        public void NavigationWaitToComplete(string url, string targetFrameName, byte[] postData, string additionalHeaders)
        {
            bool complete = false;
            NavigationAsync(url, targetFrameName, postData, additionalHeaders).ContinueWith((t) => complete = true);
            while (!complete)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }
        public async Task NavigationAsync(string url, string targetFrameName, byte[] postData, string additionalHeaders)
        {
            TaskCompletionSource<bool> tcsNavigation = new TaskCompletionSource<bool>(); ;
            TaskCompletionSource<bool> tcsDocument = new TaskCompletionSource<bool>(); ;
            Navigated += (s, e) =>
            {
                if (tcsNavigation.Task.IsCompleted)
                    return;
                tcsNavigation.SetResult(true);
            };
            DocumentCompleted += (s, e) =>
            {
                if (ReadyState != WebBrowserReadyState.Complete)
                    return;
                if (tcsDocument.Task.IsCompleted)
                    return;
                tcsDocument.SetResult(true);
            };
            Navigate(url, targetFrameName, postData, additionalHeaders);
            await tcsNavigation.Task;
            // navigation completed, but the document may still be loading
            await tcsDocument.Task;
            // the document has been fully loaded, you can access DOM here
        }
        public async Task NavigationAsync(string url)
        {
            TaskCompletionSource<bool> tcsNavigation = new TaskCompletionSource<bool>(); ;
            TaskCompletionSource<bool> tcsDocument = new TaskCompletionSource<bool>(); ;
            Navigated += (s, e) =>
            {
                if (tcsNavigation.Task.IsCompleted)
                    return;
                tcsNavigation.SetResult(true);
            };
            DocumentCompleted += (s, e) =>
            {
                if (ReadyState != WebBrowserReadyState.Complete)
                    return;
                if (tcsDocument.Task.IsCompleted)
                    return;
                tcsDocument.SetResult(true);
            };
            Navigate(url);
            await tcsNavigation.Task;
            // navigation completed, but the document may still be loading
            await tcsDocument.Task;
            // the document has been fully loaded, you can access DOM here
        }
    }
