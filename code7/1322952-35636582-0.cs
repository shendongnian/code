    public abstract class MyAbstractClass<T>
    	where T : NotifyingDatabaseObject
    {
    	public abstract IList<T> GetList(int? id) ;
    }
    
    public class MyConcreteClass : MyAbstractClass<NotifyingDatabaseObjectChildClass>
    {
    	public override IList<NotifyingDatabaseObjectChildClass> GetList(int? id)
    	{
    		return new List<NotifyingDatabaseObjectChildClass>();
    	}
    }
