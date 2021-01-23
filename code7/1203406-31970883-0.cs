    class MyClass
    {
        private object _currentKey;
        private Hashtable _myHashtable = new Hashtable(); 
        public void Method()
        {
            // ...
            _myHashtable.Add(key1, item1);
            _myHashtable.Add(key2, item2);
            _currentKey = key2;
            _myHashtable.Add(key3, item3);
        } 
    }
