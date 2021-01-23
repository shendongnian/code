        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.Document.GetElementById("ctl00_Content_Login1_UserName") != null)
            {
                // 1st case:
                webBrowser1.Document.GetElementById("ctl00_Content_Login1_UserName").SetAttribute("value", "username");
                webBrowser1.Document.GetElementById("ctl00_Content_Login1_Password").SetAttribute("value", "password");
                webBrowser1.Document.GetElementById("ctl00_Content_Login1_LoginButton").InvokeMember("click");
            }
            else if (webBrowser1.Document.Window.Frames["ContentFrame"].Document.GetElementById("btn‌​Punch") != null)
            {
                // 3rd case:
                webBrowser1.Document.Window.Frames["ContentFrame"].Document.GetElementById("btn‌​Punch").InvokeMember("Click");
                //                string content = webBrowser1.Document.Window.Frames[0].WindowFrameElement.InnerText;
                //                string content = webBrowser1.Document.Window.Frames[0].Document.Body.InnerText;
                //                MessageBox.Show(content);
                //                link.InvokeMember("Click");
            }
            else
            {
                // 2nd case:
                HtmlElement link = (from HtmlElement elem in webBrowser1.Document.GetElementsByTagName("a")
                    where elem.InnerHtml == "Time Clock Entry"
                    select elem).ElementAt(0);
                link.InvokeMember("Click");
            }
        }
