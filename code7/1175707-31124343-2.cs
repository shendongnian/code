    class MyClass
    {
        List<IWrapper> list;
        public string GetName(IWrapper aOrB)
        {
            Console.WriteLine(aOrB.Name);
        }
    }
