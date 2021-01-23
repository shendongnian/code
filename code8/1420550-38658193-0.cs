    public class DbStringTypeHandler : SqlMapper.TypeHandler<DbString>
    {
    	public override DbString Parse(object value)
    	{
    		if (value == null)
    			return null;
    		var dbStringValue = value as DbString;
    		if (dbStringValue != null)
    			return dbStringValue;
    		var stringValue = value as string;
    		if (stringValue != null)
    			return new DbString { Value = stringValue };
    		throw new InvalidCastException("Invalid cast from '" + value.GetType() + "' to '" + typeof(DbString) + "'.");
    	}
    
    	public override void SetValue(IDbDataParameter parameter, DbString value)
    	{
    		parameter.Value = value;
    	}
    }
