    public static class MyClassFactory
    {
        public static List<MyClass> CreateMyClass(int number, param1, param2, param3)
        {
            List<MyClass> items = new List<MyClass>();
            for (int counter=0;counter<number;counter++)
            {
                items.Add(new MyClass(param1,param2,param3);   
            }
            return items;
        }
    }
