    public abstract class GenericLookupModelDataService<TModel, TViewModel> : object 
        where TModel : GenericLookupModel, new()
        where TViewModel : GenericLookupViewModel, new()
    {
      // ...
