    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromDIAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource { get { return BindingSource.Services; } }
    }
    
    public class Customer
    {
        [FromDI]
        public IFooService FooService { get; set; }
    
        public string Name { get; set; }
    }
