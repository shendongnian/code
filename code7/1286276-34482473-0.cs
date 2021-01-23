    class BasicClass
    {
        public InheritedClass objTemp = new InheritedClass();
        public BasicClass()
        {
            int nameLength = objTemp.GetName().Length();
        }
    }
    class InheritedClass
    {
        protected string Name;
        public string GetName()
        {
            return Name;
        }
    }
