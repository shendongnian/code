    public static bool HasImplicitConversion( Type source, Type destination )
	{
        var sourceCode = Type.GetTypeCode( source );
        var destinationCode = Type.GetTypeCode( destination );
		switch( sourceCode )
		{
			case TypeCode.SByte:
				switch( destinationCode )
				{
					case TypeCode.Int16:
					case TypeCode.Int32:
					case TypeCode.Int64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Byte:
				switch( destinationCode )
				{
					case TypeCode.Int16:
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Int16:
				switch( destinationCode )
				{
					case TypeCode.Int32:
					case TypeCode.Int64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.UInt16:
				switch( destinationCode )
				{
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Int32:
				switch( destinationCode )
				{
					case TypeCode.Int64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.UInt32:
				switch( destinationCode )
				{
					case TypeCode.UInt32:
					case TypeCode.UInt64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				switch( destinationCode )
				{
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Char:
				switch( destinationCode )
				{
					case TypeCode.UInt16:
					case TypeCode.Int32:
					case TypeCode.UInt32:
					case TypeCode.Int64:
					case TypeCode.UInt64:
					case TypeCode.Single:
					case TypeCode.Double:
					case TypeCode.Decimal:
						return true;
				}
				return false;
			case TypeCode.Single:
				return ( destinationCode == TypeCode.Double );
		}
		return false;
	}
