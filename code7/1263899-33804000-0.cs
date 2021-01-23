    class A : Dictionary<String, MyClass>
    {
        public void Add(MyClass m)
        {
            this.Add(m.Name,m);
        }
    }
