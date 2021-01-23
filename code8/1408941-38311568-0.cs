    public class EncryptedInt
    {
        public int? Id { get; set; }
    }
    
    public class EncryptedIntModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }
    
            var rawVal = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var ei = new EncryptedInt
            {
                Id = Crypto.DecryptToInt(rawVal.AttemptedValue)
            };
            return ei;
        }
    }
    
    public class EncryptedIntAttribute : CustomModelBinderAttribute
    {
        private readonly IModelBinder _binder;
    
        public EncryptedIntAttribute()
        {
            _binder = new EncryptedIntModelBinder();
        }
    
        public override IModelBinder GetBinder() { return _binder; }
    }
