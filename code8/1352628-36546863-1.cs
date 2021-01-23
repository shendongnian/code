    class MyClass
    {
    }
    class MyInitData
    {
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var list = new List<MyClass>();
            while (true)
            {
                var initData = GetNextItem(); // Returns null when no more items are available.
                if (initData == null) // No more items available.
                    break;
                list.Add(CreateMyClassFromInitData(initData));
            }
        }
        static MyInitData GetNextItem() // Returns null when no more items are available.
        {
            // Code to return next item. Implementation omitted here.
            return null;
        }
        static MyClass CreateMyClassFromInitData(MyInitData initData)
        {
            // Create a new MyClass from initData. Implementation omitted here.
            return new MyClass();
        }
    }
