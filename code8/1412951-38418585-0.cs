    public class MyClass
    {
        // Holds the instance of web browser control
        public WebBrowser webBrowser;
    
        //Inject the WebBrowser control
        public MyClass(WebBrowser webBrowser)
        {
            this.webBrowser = webBrowser;
        }
    
        public void navigate(string url)
        {
            this.webBrowser.Navigate(url);
        } 
    } 
