    public void TestEntities<T>() where T : Base
    {
        LogicalNameAttribute logicalNameAttr = typeof(T).GetCustomAttribute<LogicalNameAttribute>();
        NumberOfCharsAttribute numberOfCharsAttr = typeof(T).GetCustomAttribute<NumberOfCharsAttribute >();
    
       Contract.Assert(logicalNameAttr != null);
       Contract.Assert(numberOfCharsAttr != null);
    
       string logicalName = logicalNameAttr.Name;
       int numberOfChars = numberOfCharsAttr.Number;
       // Other stuff
    }
