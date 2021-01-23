    public class MyClass : MyBase
    {
        public int method1()
        {
            return storage
                .ToStorageValue()
                .GetFirst()
                .Add(3)
                .Add(7)
                .GetValue(); 
        }
    }
