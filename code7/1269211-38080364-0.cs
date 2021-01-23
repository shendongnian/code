        public class BoundObject
        {
            public delegate void ItemClickedEventHandler(object sender, HtmlItemClickedEventArgs e);
            public event ItemClickedEventHandler HtmlItemClicked;
            public delegate void ItemResponseEventHandler(object sender, GetResponseEventArgs e);
            public event ItemResponseEventHandler ItemResponse;
            private ChromiumWebBrowser browser;
            public BoundObject(ChromiumWebBrowser br) { browser = br; }
            public void OnFrameLoadEnd(object sender, FrameLoadEndEventArgs e)
            {
                if (e.Frame.IsMain)
                {
                    ////browser.ExecuteScriptAsync(@"
                    ////    document.body.onmouseup = function()
                    ////    {
                    ////        bound.onSelected(window.getSelection().toString());
                    ////    }
                    ////");
                    browser.EvaluateScriptAsync(@"window.onclick = function(e) { e.preventDefault(); bound.onClicked(e.target.outerHTML); }");
                }
            }
            public void OnSelected(string selected)
            {
                MessageBox.Show("The user selected some text [" + selected + "]");
            }
            public void OnClicked(string id)
            {
                if (HtmlItemClicked != null)
                {
                    HtmlItemClicked(this, new HtmlItemClickedEventArgs() { Id = id });
                }
            }
            public void OnResponse(string projectId, string automationTaskId, string responseText)
            {
                if (ItemResponse != null)
                {
                    ItemResponse(this, new GetResponseEventArgs() { AutomationTaskId = automationTaskId, ProjectId = projectId, ResponseText = responseText });
                }
            }
        }
        public class HtmlItemClickedEventArgs : EventArgs
        {
            public string Id { get; set; }
        }
        public class GetResponseEventArgs : EventArgs
        {
            public string ProjectId { get; set; }
            public string AutomationTaskId { get; set; }
            public string ResponseText { get; set; }
        }
        
