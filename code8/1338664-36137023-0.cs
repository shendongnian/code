    class DerivedClass : BaseClass
    {
        public DerivedClass(string somethingNew) 
            : base()
        {
            setVals(somethingNew);
        }
        public DerivedClass(string somethingNew, int someVal)
            : base(someVal)
        {
            setVals(somethingNew);
        }
        private setVals(string somethingNew) 
        {
            // do something with the somethingNew varible
        }
    }
