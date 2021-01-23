    class YourDataClass {
      public string ColumnName; 
    }
    
    var query = (from name in some.Table
                select new YourDataClass { ColumnName = name });
    YourMethod(query);
...
    YourMethod(IEnumerable<YourData> enumerable);
