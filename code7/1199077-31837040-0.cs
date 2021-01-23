            public Form1()
            {
                InitializeComponent();
                this.Load += Form1_Load;
            }
    
            void Form1_Load(object sender, EventArgs e)
            {
                webBrowserControl.Navigate("file:///C:/Temp/span.html");
                webBrowserControl.Navigated += webBrowserControl_Navigated;
            }
    
            void webBrowserControl_Navigated(object sender, WebBrowserNavigatedEventArgs e)
            {
                InjectCookieSetterScript();
            }
    
            private void InjectCookieSetterScript()
            {
                String script =
    @"function setCookie()
    {
        document.cookie = ""myCookie=value;path=/"";
    }";
                InjectScript(script);
                webBrowserControl.Document.InvokeScript("setCookie");
            }
    
            public void InjectScript(String scriptText)
            {    
                var headElements = webBrowserControl.Document.GetElementsByTagName("head");
                if (headElements.Count == 0)
                {
                    throw new IndexOutOfRangeException("No element with tag 'head' has been found in the document");
                }
                var headElement = headElements[0];
    
                var script = webBrowserControl.Document.CreateElement("script");
                script.InnerHtml = scriptText; // "<script>" + scriptText + "</script>";
                headElement.AppendChild(script);
            }
        }
