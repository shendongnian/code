        bool login = false;
        bool nav = false;
        bool beware = true;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                HtmlDocument doc = webBrowser1.Document;
                if (login && !nav)
                {
                    HtmlElement timetable = null;
                    foreach (HtmlElement link in doc.GetElementsByTagName("li"))
                    {
                        Console.WriteLine(link.InnerText);
                        if (beware)
                        {
                            timetable = link; //Avoiding NullExceptions
                        }
                        if (link.InnerText.Contains("Timetablelol"))
                        {
                            timetable = link; //Set the Timetable var.
                            beware = false; //Keep Timetable the kept element.
                        }
                    }
                    timetable.InvokeMember("click"); //Clicking on timetable link.
                    nav = true;
                }
                if (!login && !nav)
                {
                    HtmlElement username = doc.GetElementById("loginUsername");
                    HtmlElement password = doc.GetElementById("loginPassword");
                    HtmlElement submit = doc.GetElementById("loginSubmit");
                    username.SetAttribute("value", "myusername");
                    password.SetAttribute("value", "mypassword");
                    submit.InvokeMember("click");
                    login = true;
                }
            }
            catch
            {
                Console.WriteLine("Didn't work");
            }
        }
