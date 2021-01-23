    public static void Bind(this object destination, object source)
    		{
    			if (source != null)
    			{
    				var destProperties = destination.GetType().GetProperties();
    				foreach (var sourceProperty in source.GetType().GetProperties())
    				{
    					var availableDestinationProperties = destProperties.Where(x=>x.Name == sourceProperty.Name && x.PropertyType.IsAssignableFrom(sourceProperty.PropertyType));
    
    					if (availableDestinationProperties.Count() == 0)
    					{
    						continue;
    					}
    
    					var destProperty = availableDestinationProperties.Single();
    
    					var sourcePropertyValue = sourceProperty.GetValue(source, null);
    					var destPropertyType = destProperty.PropertyType;    
    					
    					if (sourcePropertyValue != null)
    					{	
    						if (IsCollection(destPropertyType))
    						{
    							//handle collections: either do collection item references copy, do deep copy of each element in collection, etc.. 
    						}
    
    						if (IsReferenceType(destPropertyType))
    						{
    							//do deep copy with recursion: create object OR do reference copy in case you need this
    						}
    
    						destProperty.SetValue(destination, sourcePropertyValue, new object[] { });
    					}
    				}
    			}
    		}
