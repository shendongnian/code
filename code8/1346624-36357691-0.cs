            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        try
        {
            HtmlDocument doc = logger.Document;
            HtmlElement username = doc.GetElementById("loginUsername");
            HtmlElement password = doc.GetElementById("loginPassword");
            HtmlElement submit = doc.GetElementById("loginSubmit");
            username.SetAttribute("value", "myusername");
            password.SetAttribute("value", "mypassword");
            submit.InvokeMember("click");
            HtmlElement timetable;
            foreach (HtmlElement link in doc.GetElementsByTagName("li"))
            {
                if (link.InnerText.Equals("Timetable"))
                {
                    if (link.OuterHtml.Contains("<ul id=\"navigation\">")){
                        timetable = link;
                    }
                }
            }
            timetable.InvokeMember("click"); //Clicking on timetable link.
            //Your code goes here...
        }
        catch
        {
        }
    }
