	private static bool IsTable(DynValue table)
	{
		switch (table.Type)
		{
			case DataType.Table:
				return true;
			case DataType.Boolean:
			case DataType.ClrFunction:
			case DataType.Function:
			case DataType.Nil:
			case DataType.Number:
			case DataType.String:
			case DataType.TailCallRequest:
			case DataType.Thread:
			case DataType.Tuple:
			case DataType.UserData:
			case DataType.Void:
			case DataType.YieldRequest:
				break;
		}
		return false;
	}
