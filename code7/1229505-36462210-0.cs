    public class MyModule : NinjectModule
    {
        private string _index;
    
        public MyModule(string index)
        {
            _index = index;
        }
    
        public override void Load()
        {
            Bind<ConfigurationType>().ToConstant(new ConfigurationType(_index));
            Bind<ParentClass>().ToSelf();
            Bind<ChildClass>().ToSelf();
        }  
    }
    public class ParentClass
    {
        private string _index;
        private ChildClass _childClass;
    
        public ParentClass(ConfigurationType configuration, ChildClass childClass)
        {
            _index = configuration.Index;
            _childClass = childClass;
        }
    }
    public class ChildClass
    {
        private string _index;
    
        public ChildClass(ConfigurationType configuration configuration)
        {
            _index = configuration.Index;
        }
    
        public string Index { get; set; }
    }
