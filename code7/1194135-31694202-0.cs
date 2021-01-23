    public class ViewModel<TModel> : ViewModelBase
        where TModel : ModelBase
    {
        public TModel Model { get; protected set; }
        public ViewModel(TModel model)
        {
            Model = model;
        }
        ...
    }
