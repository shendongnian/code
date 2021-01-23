    public class MyClientClass
    {
        private MyPageClass p = new MyPageClass();
    
        private void ProcessMorePages()
        {
            // Register ProcessLoadedPage as event handler
            p.FirstPageLoaded += ProcessLoadedPage; 
        }    
    
        // This method has the same signature as the EventHandler delegate
        // It will be called back inside p.MorePageProcessing
        private void ProcessLoadedPage(object sender, EventArgs e)
        {
            ...
        }
    }
