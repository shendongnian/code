    public static class SqlExtensions
    {
    	private static readonly IDictionary<SqlDbType, Type> TypeMap = new Dictionary<SqlDbType, Type>
    		{
    			{ SqlDbType.TinyInt, typeof(byte) },
    			{ SqlDbType.SmallInt, typeof(short) },
    			{ SqlDbType.Int, typeof(int)},
    			{ SqlDbType.BigInt,typeof(long) },
    			{ SqlDbType.Image, typeof(byte[])},
    			{ SqlDbType.Bit, typeof(bool)},
    			{ SqlDbType.DateTime, typeof(DateTime)},
    			{ SqlDbType.DateTime2, typeof(DateTime)},
    			{ SqlDbType.DateTimeOffset, typeof(DateTimeOffset)},
    			{ SqlDbType.NVarChar,typeof(string) },
    			{ SqlDbType.VarChar, typeof(string)},
    			{ SqlDbType.Text, typeof(string)},
    			{ SqlDbType.NText, typeof(string)},
    			{ SqlDbType.Char, typeof(char)},
    			{ SqlDbType.NChar, typeof(char)},
    			{ SqlDbType.Money, typeof(decimal)},
    			{ SqlDbType.Real, typeof(float)},
    			{ SqlDbType.Float, typeof(double)},
    			{ SqlDbType.Time, typeof(TimeSpan)}
    			// add the rest here
    		};
    	
    	public static Type ToType(this SqlDbType type)
    	{
    		if (TypeMap.ContainsKey(type))
    		{
    			return TypeMap[type];
    		}
    
    		throw new ArgumentException($"{type} is not a supported");
    	}
    }
