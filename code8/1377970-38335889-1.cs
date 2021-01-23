    public class MessageModelBinder : IModelBinder
    {
        private readonly IModelMetadataProvider _metadataProvider;
        private readonly Dictionary<string, IModelBinder> _binders;
    
        public MessageModelBinder(IModelMetadataProvider metadataProvider, Dictionary<string, IModelBinder> binders)
        {
            _metadataProvider = metadataProvider;
            _binders = binders;
        }
    
        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var messageTypeModelName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, "messageType");
            var messageTypeResult = bindingContext.ValueProvider.GetValue(messageTypeModelName);
            if (messageTypeResult == ValueProviderResult.None)
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }
    
            IModelBinder binder;
            if (!_binders.TryGetValue(messageTypeResult.FirstValue, out binder))
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }
    
            // Now know the type exists in the assembly.
            var type = Type.GetType(messageTypeResult.FirstValue);
            var metadata = _metadataProvider.GetMetadataForType(type);
    
            ModelBindingResult result;
            using (bindingContext.EnterNestedScope(metadata, bindingContext.FieldName, bindingContext.ModelName, model: null))
            {
                await binder.BindModelAsync(bindingContext);
                result = bindingContext.Result;
            }
    
            bindingContext.Result = result;
        }
    }
