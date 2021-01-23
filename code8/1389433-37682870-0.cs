    public void ProcessObj<T>(T obj, Func<T, IEnumerable<object>> includes) {
         var objBaseObject = obj as BaseObject;
        if (objBaseObject == null) return;
        // Create a reusable action to use on both the parent and the children
        Action<BaseObject> action = x => x.Id += 100;
        
        // Run the action against the root object
        action(objBaseObject);
        
        // Get the includes by just invoking the delegate. No need for trees.
        var includes = includes(obj);
        
        // Loop over each item in each collection. If the types then invoke the same action that we used on the root. 
        foreach(IEnumerable<object> include in includes) 
        {
           foreach(object item in include) 
           {
              var childBaseObject = item as BaseObject;
              if(childBaseObject != null) 
              {
                action(childBaseObject);          
              }
           }
        }
    }
