    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigated += webBrowser1_Navigated;
            webBrowser1.Navigate("www.google.com");
        }
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var scriptingObject = new UserAgentScriptingObject();
            webBrowser1.ObjectForScripting = scriptingObject;
            HtmlElement scriptEl = webBrowser1.Document.CreateElement("script");
            scriptEl.InnerText = "function myscript() { window.external.SetUserAgent(navigator.userAgent); }";
            webBrowser1.Document.GetElementsByTagName("head")[0].AppendChild(scriptEl);
            webBrowser1.Document.InvokeScript("myscript");
        }
    }
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class UserAgentScriptingObject
    {
        public void SetUserAgent(string userAgent)
        {
            MessageBox.Show(userAgent);
        }
    }
