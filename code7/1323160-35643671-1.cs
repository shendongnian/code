    class MyClass
    {
        public List<int> MyProperty { get { return new List<int>() { 3, 4, 5, 6 }; } }
    }
    class Program
    {        
        static void Main()
        {
            MyClass instance = new MyClass();
            PropertyInfo info = instance.GetType().GetProperty("MyProperty");
            List<int> another = info.GetValue(instance) as List<int>;
            for (int i = 0; i < another.Count; i++)
            {
                Console.Write(another[i] + "   ");
            }
        }
    }
