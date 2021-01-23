    public class MyClass
    {
        public int? FirstInteger { get; set; }
        public int? SecondInteger { get; set; }
    }
    public class AwesomeAlgorithm
    {
        public static void DoSomething(MyClass c)
        {
            try
            {
                throw new InvalidOperationException("Something is missing.");
            }
            catch(InvalidOperationException)
            {
                foreach(PropertyInfo t in c.GetType().GetProperties())
                {
                    if(t.GetValue(c) == null)
                    {
                        //Your code would go here. Console.Writeline as example.
                        Console.WriteLine("Property {0} appears to be null.", t.Name);
                    }
                }
            }
        }
    }
