	public static class DotNetTypeToPostgreSqlType
	{
		public static string GetPostgreType(object o)
		{
			if (o is Int64)
			{
				return "int8";
			}
			if (o is Boolean)
			{
				return "bool";
			}
			if (o is Byte[])
			{
				return "bytea";
			}
			if (o is DateTime)
			{
				return "date";
			}
			if (o is Double)
			{
				return "float8";
			}
			if (o is Int32)
			{
				return "int4";
			}
			if (o is Decimal)
			{
				return "money";
			}
			if (o is Decimal)
			{
				return "numeric";
			}
			if (o is Single)
			{
				return "float4";
			}
			if (o is Int16)
			{
				return "int2";
			}
			if (o is String)
			{
				return "text";
			}
			if (o is DateTime)
			{
				return "time";
			}
			if (o is DateTime)
			{
				return "timetz";
			}
			if (o is DateTime)
			{
				return "timestamp";
			}
			if (o is DateTime)
			{
				return "timestamptz";
			}
			if (o is TimeSpan)
			{
				return "interval";
			}
			if (o is String)
			{
				return "varchar";
			}
			if (o is IPAddress)
			{
				return "inet";
			}
			if (o is Boolean)
			{
				return "bit";
			}
			if (o is Guid)
			{
				return "uuid";
			}
			if (o is Array)
			{
				return "array";
			}
			throw new NotImplementedException("Unknown postgresql type");
		}
	}
