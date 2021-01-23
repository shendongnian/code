    var regs = mefContainer.GetExportTypesWithMetadata<ViewModelBase, IViewModelMetadata>();
    foreach (var reg in regs)
    {
        unityContainer.RegisterType(typeof (ViewModelBase), reg.Key, reg.Value.Name);
    }
