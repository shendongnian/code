    object objDbValue = DbReader.GetValue(columnIndex);
    Type sqlType = DbReader.GetFieldType(columnIndex);
    Type clrType = null;
    
    if (sqlType.Name.StartsWith("Sql"))
    {	
    	var objClrValue = objDbValue.GetType()
    								.GetProperty("Value")
    							    .GetValue(objDbValue, null);
    	clrType = objClrValue.GetType();
    }
