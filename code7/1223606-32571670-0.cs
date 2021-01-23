    Dictionary<string, Type> attributes = new Dictionary<string, Type>();
    attributes.Add("attrName1", typeof(string));
    attributes.Add("attrName2", typeof(long));
    attributes.Add("attrName3", typeof(DateTime));
    attributes.Add("attrName4", typeof(ArrayList));
    object[] Items = new object[4];
    Items[0] = "Test";
    Items[1] = 11111L; 
    Items[2] = new DateTime();
    Items[3] = new ArrayList();
    object Buffer;
    object Val;
    int i = 0;
    foreach(KeyValuePair<string, Type> attr in attributes)
    {
        Buffer = Items[i++];
    
        //Try this expression 
    	var DataParam = Expression.Parameter(typeof(object), "Buffer");
            var Body = Expression.Block(Expression.Convert(Expression.Convert(DataParam, attr.Value), attr.Value));
    
            var Run = Expression.Lambda(Body, DataParam).Compile();
            var ret = Run.DynamicInvoke(Buffer);
           
    	
    }
