    class IniKeyCollection : Collection<IniKey>
    {
        private IniKey[] arr = new IniKey[100];
        public IniKey this[string name]
        {
            get
            {
                return arr.Where(x => x.Name == name).DefaultIfEmpty(null).Single();
            }
            set
            {
                //Not implemented
            }
        }
    }
