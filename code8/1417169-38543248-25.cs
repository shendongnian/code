    public class MyClientClass
    {
        private MyPageClass p = new MyPageClass();
    
        private void ProcessPages()
        {
            // Pass DoFirstPageStuff as callback function
            p.SomePageProcessing(DoFirstPageStuff, 7); 
        }    
    
        // This method has the signature specified by the FirstPageCallback delegate
        // It will be called inside p.SomePageProcessing
        private void DoFirstPageStuff(string title)
        {
            // Do something with the page title
            ...
        }
    }
