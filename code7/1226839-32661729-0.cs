    using AutoFactory;
    class ViewModelFactory
    {
    	private IAutoFactory<IEditViewModelBase> _editFactory = Factory.Create<IEditViewModelBase>();
    	private IAutoFactory<IListViewModelBase> _listFactory = Factory.Create<IListViewModelBase>();
       
    	public IEditViewModelBase CreateEditViewModel<T>()
        {
            return _editFactory.SeekPart(t => t.BaseType.GetGenericArguments()[0].Name == typeof(T).Name);
        }
    
        public IListViewModelBase CreateListViewModel<T>()
        {
    		return _listFactory.SeekPart(t => t.BaseType.GetGenericArguments()[0].Name == typeof(T).Name);
        }
    }
