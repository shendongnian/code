    public class MyPageClass
    {
        public delegate void FirstPageCallback(string pageTitle);
    
        // Method with a callback function
        public void SomePageProcessing(FirstPageCallback fpcb, int pageNumber)
        {
            // Do some stuff
            ...
            // Call the function defined in another class
            fpcb("This is a title");
        }
    }
