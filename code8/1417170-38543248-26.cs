    public class MyPageClass
    {
        public event EventHandler FirstPageLoaded;
    
        public void MorePageProcessing(int pageNumber)
        {
            // Do some stuff
            ...
            // Call all the registered event handlers
            if (FirstPageLoaded != null)
            {
                FirstPageLoaded(this, EventArgs.Empty);
            }
        }
    }
