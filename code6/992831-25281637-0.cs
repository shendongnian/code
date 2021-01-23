    Dictionary<String, Dictionary<String, List<Link>>> index;
    
    if (index.ContainsKey(obj.Field1))
    {
       var subIndex = index[obj.Field1];
       if (subIndex.ContainsKey(obj.Field2))
       {
          var linkList = subIndex[obj.Field2];
          foreach(var Link in linkList)
          {
              if (Link.Decide(obj))
              {
                  return Link.Aggregate(objects, otherObjects);
              } 
          }
       }
    }
