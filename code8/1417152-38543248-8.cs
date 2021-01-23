    public class MyPageClass
    {
        public delegate void FirstPageHandler(string pageTitle);
    
        // Method with a callback function
        public void SomePageProcessing(FirstPageHandler firstPageHandler, int pageNumber)
        {
            // Do some stuff
            ...
            // Call back the function defined in another class
            firstPageHandler("This is a title");
        }
    }
