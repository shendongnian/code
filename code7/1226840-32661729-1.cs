    using Autofac.Builder;
    using Autofac.Features.Metadata
    class ViewModelFactory
    {
    	private IContainer _container;
    	private IEnumerable<Meta<Lazy<IEditViewModelBase>>> _editParts;
    
       	public ViewModelFactory()
    	{
        	var builder = new ContainerBuilder();
           	builder.RegisterAssemblyTypes(this.GetType().Assembly)
               .Where(t => typeof(IEditViewModelBase).IsAssignableFrom(t))
               .As<IEditViewModelBase>()
               .WithMetadata("type", t => t.BaseType.GetGenericArguments()[0]);
           	_container = builder.Build();
           	_editParts = _container.Resolve<IEnumerable<Meta<Lazy<IEditViewModelBase>>>>();
    	}
    	
    	public IEditViewModelBase CreateEditViewModel<T>()
        {
    		return _editParts.FirstOrDefault(p => p.Metadata["type"] as Type == typeof(T)).Value.Value;
        }
        ...
    }
