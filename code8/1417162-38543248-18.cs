    public class MyPageClass
    {
        public delegate void FirstPageCallback(string pageTitle);
    
        // Method with a callback function
        public void SomePageProcessing(FirstPageCallback firstPageCallback, int pageNumber)
        {
            // Do some stuff
            ...
            // Call back the function defined in another class
            firstPageCallback("This is a title");
        }
    }
