    public static Func<Type, DependencyObject, object, UIElement> LocateForModelType = (modelType, displayLocation, context) =>{
        var viewTypeName = modelType.FullName.Replace("Model", string.Empty);
        if(context != null)
        {
            viewTypeName = viewTypeName.Remove(viewTypeName.Length - 4, 4);
            viewTypeName = viewTypeName + "." + context;
        }
    
        var viewType = (from assmebly in AssemblySource.Instance
                        from type in assmebly.GetExportedTypes()
                        where type.FullName == viewTypeName
                        select type).FirstOrDefault();
    
        return viewType == null
            ? new TextBlock { Text = string.Format("{0} not found.", viewTypeName) }
            : GetOrCreateViewType(viewType);
    };
