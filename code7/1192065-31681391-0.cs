    class Entity 
    {
         Dictionary<Attribute, Object> attributeRepositoryEnumMap;
         ...
         public dynamic getAttribute(Attribute attribute){
		     Object result = attributeRepositoryEnumMap[attribute];
		     return result;
	     }
    }
