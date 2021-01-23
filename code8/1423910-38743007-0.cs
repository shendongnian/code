    class MyClass
    {
        IList<int> someList;
    
        public MyClass(params int[] values)
        {
            someList = new List<int>();
            foreach (int value in values)
            {
                someList.Add(value);
            }
        }
    }
