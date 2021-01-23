    public class MyClass
    {
        //now this is field is accessible from any method of declared within this class
        private List<Float> section;
        public MyClass()
        {
            section = new List<Float>();
        }
        private void someMethod()
        {   
            Console.WriteLine(section[0]); // example 
        }
    }
