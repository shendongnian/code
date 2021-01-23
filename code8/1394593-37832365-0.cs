    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            class1.Example += Class1_Example;
            Console.WriteLine("Default triggering");
            class1.DoSomething();
            Console.WriteLine("via GetInvocationList");
            class1.CheckEventInfo();
            Console.ReadLine();
        }
        private static void Class1_Example(object sender, EventArgs e)
        {
            Console.WriteLine("Class1_Example Method: ");
        }
    }
---
    class Class1
    {
        public void CheckEventInfo()
        {
            if (Example != null)
                foreach (var item in Example.GetInvocationList())
                {
                    Console.WriteLine("GetInvocationList method:" + item.Method.Name);
                    Console.WriteLine("GetInvocationList class:" + item.Method.DeclaringType.FullName);
                    item.DynamicInvoke(this, EventArgs.Empty);
                }
        }
        public void DoSomething()
        {
            Example?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler Example;
    }
