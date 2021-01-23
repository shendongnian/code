    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Windows.Forms;
    namespace myTest.WinFormsApp
    {
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = @"
                <html>
                <body>
                <img alt=""0764547763 Product Details"" 
                    src=""http://ecx.images-amazon.com/images/I/51AK1MRIi7L._AA160_.jpg"">
                <hr/>
                <h2>Product Details</h2>
                <ul>
                <li><b>Paperback:</b> 648 pages</li>
                <li><b>Publisher:</b> Wiley; Unlimited Edition edition (October 15, 2001)</li>
                <li><b>Language:</b> English</li>
                <li><b>ISBN-10:</b> 0764547763</li>
                </html>
            ";
        }
        private void cmdTest_Click(object sender, EventArgs e)
        {
            var processor = new WebBrowserControlXPathQueriesProcessor(webBrowser1);
            // change attributes of the first element of the list
            {
                var li = processor.GetHtmlElement("//li");
                li.innerHTML = string.Format("<span style='text-transform: uppercase;font-family:verdana;color:green;'>{0}</span>", li.innerText);
            }
            // change attributes of the second and subsequent elements of the list
            var list = processor.GetHtmlElements("//ul//li");
            int index = 1;
            foreach (var li in list)
            {
                if (index++ == 1) continue;
                li.innerHTML = string.Format("<span style='text-transform: uppercase;font-family:verdana;color:blue;'>{0}</span>", li.innerText);
            }
        }
        /// <summary>
        /// Enables IE WebBrowser control to evaluate XPath queries 
        /// by injecting http://svn.coderepos.org/share/lang/javascript/javascript-xpath/trunk/release/javascript-xpath-latest-cmp.js
        /// and to return XPath queries results to the calling C# code as strongly typed
        /// mshtml.IHTMLElement and IEnumerable<mshtml.IHTMLElement>
        /// </summary>
        public class WebBrowserControlXPathQueriesProcessor
        {
            private System.Windows.Forms.WebBrowser _webBrowser;
            public WebBrowserControlXPathQueriesProcessor(System.Windows.Forms.WebBrowser webBrowser)
            {
                _webBrowser = webBrowser;
                injectScripts();
            }
            private void injectScripts()
            {
                // Thanks to: http://stackoverflow.com/questions/7998996/how-to-inject-javascript-in-webbrowser-control
                HtmlElement head = _webBrowser.Document.GetElementsByTagName("head")[0];
                HtmlElement scriptEl = _webBrowser.Document.CreateElement("script");
                mshtml.IHTMLScriptElement element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
                element.src = "http://svn.coderepos.org/share/lang/javascript/javascript-xpath/trunk/release/javascript-xpath-latest-cmp.js";
                head.AppendChild(scriptEl);
                string javaScriptText = @"
                        function GetElements (XPath) {
                                var xPathRes = document.evaluate ( XPath, document, null, XPathResult.ORDERED_NODE_ITERATOR_TYPE, null);              
                                var nextElement = xPathRes.iterateNext ();
                                var elements = new Object();
                                var elementIndex = 1;
                                while (nextElement) {
                                elements[elementIndex++] = nextElement;
                                nextElement = xPathRes.iterateNext ();
                                }
                            elements.length = elementIndex -1;
                            return elements;
                            };
                       ";
                scriptEl = _webBrowser.Document.CreateElement("script");
                element = (mshtml.IHTMLScriptElement)scriptEl.DomElement;
                element.text = javaScriptText;
                head.AppendChild(scriptEl);
            }
            /// <summary>
            /// Gets Html element's mshtml.IHTMLElement object instance using XPath query
            /// </summary>
            public mshtml.IHTMLElement GetHtmlElement(string xPathQuery)
            {
                string code = string.Format("document.evaluate('{0}', document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;", xPathQuery);
                return _webBrowser.Document.InvokeScript("eval", new object[] { code }) as mshtml.IHTMLElement;
            }
            /// <summary>
            /// Gets Html elements' IEnumerable<mshtml.IHTMLElement> object instance using XPath query
            /// </summary>
            public IEnumerable<mshtml.IHTMLElement> GetHtmlElements(string xPathQuery)
            {
                // Thanks to: http://stackoverflow.com/questions/5278275/accessing-properties-of-javascript-objects-using-type-dynamic-in-c-sharp-4
                var comObject = _webBrowser.Document.InvokeScript("eval", new object[] { string.Format("GetElements('{0}')", xPathQuery) });
                Type type = comObject.GetType();
                int length = (int)type.InvokeMember("length", BindingFlags.GetProperty, null, comObject, null);
                for (int i = 1; i <= length; i++)
                {
                    yield return type.InvokeMember(i.ToString(), BindingFlags.GetProperty, null, comObject, null) as mshtml.IHTMLElement;
                }
            }
        }
    }
    }
