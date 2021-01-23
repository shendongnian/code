            HtmlElement hleGetData = (HtmlElement)hdoc.GetElementById("getButton");
            hleGetData.InvokeMember("click");
            while (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                System.Windows.Forms.Application.DoEvents();
            };
            System.Threading.Thread.Sleep(1000);
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
            System.Windows.Forms.Application.DoEvents();
