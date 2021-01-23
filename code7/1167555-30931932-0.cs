    public class DirtyPropertiesBase
    {
        ...
        
        // most of these come from Yappi
        public static class Create<TConcept> where TConcept : DirtyPropertiesBase
        {
            public static readonly Type Type =PropertyProxy.ConstructType<TConcept, PropertyMap<TConcept>>(new Type[0], true);
            public static Func<TConcept> New = Constructor.Compile<Func<TConcept>>(Type);
        }
        private readonly List<string> _dirtyList = new List<string>();
        protected void OnPropertyChanged(string name)
        {
            if (!_dirtyList.Contains(name))
            {
                _dirtyList.Add(name);
            }
        }
        public bool IsPropertyDirty(string name)
        {
            return _dirtyList.Contains(name);
        }
        
        ...
    }
