    // List of data
    List<string> names = new List<string> { "Fred", "John", "Jane" };
    // Create ADODB Recordset
    var adors = new ADODB.Recordset();
    adors.Fields.Append("name", ADODB.DataTypeEnum.adLongVarChar, 250, FieldAttributeEnum.adFldIsNullable);
    adors.Open(System.Reflection.Missing.Value, System.Reflection.Missing.Value, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic, -1);
    // Loop through data and add a row for each one
    foreach (var name in names)
    {
        adors.AddNew();
        adors.Fields["name"].Value = name;
        adors.Update(System.Reflection.Missing.Value, System.Reflection.Missing.Value);
    }
    
    // Set recordset back to starting position
    adors.AbsolutePosition = (PositionEnum)1;
    // Return Recordset
    return adors;
