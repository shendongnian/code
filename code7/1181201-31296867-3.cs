    public class DatabaseEntity
	{
	    public int ID { get; set; }
	
	    public override bool Equals(object other)
	    {
	        // Turn a null answer into true: if the most derived class has not
	        // eliminated the possibility of equality, this and other are equal.
	        return BaseEquals(other) ?? true;
	    }
	
	    protected virtual bool? BaseEquals(object other)
	    {
	        if (other == null)
	            return false;
	        if (ReferenceEquals(this, other))
	            return true;
	        if (GetType() != other.GetType())
	            return false;
	
	        DatabaseEntity databaseEntity = (DatabaseEntity)other;
	        if (ID != databaseEntity.ID)
	            return false;
	        return null;
	    }
	}
	
	public class Person : DatabaseEntity
	{
	    public string FirstName { get; set; }
	    public string LastName { get; set; }
	
	    protected override bool? BaseEquals(object other)
	    {
	    	bool? baseEquals = base.BaseEquals(other);
	        if (baseEquals != null)
	            return baseEquals;
	
	        Person person = (Person)other;
	        if (person.FirstName != FirstName || person.LastName != LastName)
	            return false;
	        return null;
	    }
	}
