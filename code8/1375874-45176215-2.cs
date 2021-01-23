    public partial class Builder
    {
    	#region <Methods>
    
    	public T CreateInstance<T>(IDemoDbUnitOfWork unitOfWork, bool byFullName = false)
    	{
    		if (unitOfWork == null)
    			throw new ArgumentNullException("UnitOfWork");
    
    		var container = IoC.Initialize();
    		container.Inject(typeof(IDemoDbUnitOfWork), unitOfWork);
    
    		return container.GetInstance<T>();
    	}
    
    	#endregion
    }
