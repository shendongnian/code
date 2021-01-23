    Func<Object, SqlDbType> getSqlType = val => new SqlParameter("Test", val).SqlDbType;
    Func<Type, SqlDbType> getSqlType2 = type => new SqlParameter("Test", type.IsValueType?Activator.CreateInstance(type):null).SqlDbType;
    
    //returns nvarchar...
    Object obj = "valueToTest";
    getSqlType(obj).Dump();
    getSqlType2(typeof(String)).Dump();
    
    //returns int...
    obj = 4;
    getSqlType(obj).Dump();
    getSqlType2(typeof(Int32)).Dump();
    
    //returns bigint...
    obj = Int64.MaxValue;
    getSqlType(obj).Dump();
    getSqlType2(typeof(Int64)).Dump();
