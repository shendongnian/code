    public class MyClass
    {
        private string parameter;
    
        /// <summary>
        /// конструктор
        /// </summary>
        public MyClass(string parameter)
        {
            this.parameter = parameter;
        }
    
        public void MyMethod(string value)
        {
            Console.Write("You parameter is '{0}' and value is '{1}'", parameter, value);
        }
    }
