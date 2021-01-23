    static Dictionary<Type, Type> TypeMap = new Dictionary<Type, Type>
	{
		{typeof(ModelA), typeof(ViewModelA)},
		{typeof(ModelB), typeof(ViewModelB)},
		{typeof(ModelC), typeof(ViewModelC)}
	};
	static ViewModelBase CreateViewModel(ModelBase someObject)
	{
		return Activator.CreateInstance(TypeMap[someObject.GetType()]);
	}
