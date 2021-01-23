       private void wfhSample_Loaded(object sender, RoutedEventArgs e)
        {
            bool complete = false;
            (wfhSample.Child as System.Windows.Forms.WebBrowser).DocumentCompleted += delegate
            {
                if (complete)
                    return;
                complete = true;
                // DocumentCompleted is fired before window.onload and body.onload
                (wfhSample.Child as System.Windows.Forms.WebBrowser).Document.Window.AttachEventHandler("onload", delegate
                {
                    // Defer this to make sure all possible onload event handlers got fired
                    System.Threading.SynchronizationContext.Current.Post(delegate
                    {
                        // try webBrowser1.Document.GetElementById("id") here
                        //System.Windows.MessageBox.Show("window.onload was fired, can access DOM!");
                        var bla = (wfhSample.Child as System.Windows.Forms.WebBrowser).Document.DomDocument;
                        HTMLDocumentEvents2_Event _docEvent = (HTMLDocumentEvents2_Event)(wfhSample.Child as System.Windows.Forms.WebBrowser).Document.DomDocument;
                        _docEvent.onclick += new HTMLDocumentEvents2_onclickEventHandler(OldClickEventHandler);
                    }, null);
                });
            };
            
            (wfhSample.Child as System.Windows.Forms.WebBrowser).Navigate("http://www.example.com");
        }
        private bool OldClickEventHandler(mshtml.IHTMLEventObj e)
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            System.Drawing.Point refPoint = (wfhSample.Child as System.Windows.Forms.WebBrowser).PointToClient(new System.Drawing.Point(point.X, point.Y));
            System.Windows.Forms.HtmlElement refHtmlElement = (wfhSample.Child as System.Windows.Forms.WebBrowser).Document.GetElementFromPoint(refPoint);
            var restult = refHtmlElement.TagName; 
            return true;
        }
