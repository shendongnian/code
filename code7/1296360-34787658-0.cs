       class InheritClass : List<ITest>
    {
        public InheritClass(object parameter)
        {
            // do something
        }
    }
    class test
    {
        public test()
        {
            InheritClass a = new InheritClass(new object());
            a.Add(new ITest);
        }
    }
