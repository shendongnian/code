    if (xType == typeof(Int32))
    {
        oraParam.UdtTypeName = "SYS.ODCINUMBERLIST";
        var castArray = x.Cast<Int32>().ToArray();
        VArray newArray = new VArray();
        newArray.Array = castArray;
        oraParam.OracleDbType = OracleDbType.Array;
        oraParam.Value = newArray;
        return oraParam;
    }
