    public class MyViewModel : ViewModelBase
    {
        internal static Func<string> MyPropertyInjector = () => MyStaticClass.PropertyOne;
    
        public string MyProperty { get; set; }
    
        //whatever...
    
        public void FooMethod()
        {
            this.MyProperty = MyPropertyInjector();
        }
    }
