    public class MyClass
    {
        // this field is accessible from any method declared within this class
        private List<Float> section;
        public MyClass()
        {
            section = new List<Float>();
        }
        private void someMethod()
        {
            section.Add(2.2);    
            Console.WriteLine(section[0]); // example 
        }
    }
