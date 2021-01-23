    public class Foo
    {
        public void SetSomeValue(int someParam)
        {
            var propertyInfo = this.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public).First(t => t.Name == "SomeValue");
    
            propertyInfo.SetValue(this, someParam, null);
        }
    }
    
    public class Bar : Foo
    {
        public int SomeValue
        {
            get;
            set;
        }
    }
