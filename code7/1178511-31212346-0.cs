    public class Base
    {
        public Base()
        {
            string methodName = this.GetType().GetMethods()
                                              .Where(m => m.GetCustomAttributes<FactAttribute>().Any())
                                              .Select(m => m.Name)
                                              .FirstOrDefault();
            Console.WriteLine("Test method name is "+ methodName); // how to get test method     name here.
        }
    }
