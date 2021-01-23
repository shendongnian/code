    public static class ObjectExtension
    {
        private static readonly MethodInfo MemberwiseCloneMethod = typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance);
    
        public static object CloneObject(this object objSource)
        {
    	    return InnerCloneObject(objSource, new Dictionary<object, object>(ObjectReferenceEqualityComparer<object>.Default)));
    	}
    	
    	
    	private static object InnerCloneObject(this object objSource, IDictionary<object, object> alreadyVisitedInstances)
        {
    	    if (objSource == null)
    		{
    		    return null;
    		}
    		
    		var instanceType = objSource.GetType();
            if (IsPrimitive(instanceType) || instanceType.IsMarshalByRef)
            {
                return objSource;
            }
    
            object clonedInstance;
            if (alreadyVisitedInstances.TryGetValue(objSource, out clonedInstance))
            {
                // We already have a clone...
                return clonedInstance;
            }
    
            if (typeof(Delegate).IsAssignableFrom(instanceType))
            {
                // Copying delegates is very hard...
                return null;
            }
    
    		// Don't use activator because it needs a parameterless constructor.
            objTarget = MemberwiseCloneMethod.Invoke(objSource, null);
    		alreadyVisitedInstances.Add(objSource, objTarget);
    	        
            //Get all the properties of source object type
            PropertyInfo[] propertyInfo = typeSource.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
            //Assign all source property to taget object 's properties
            foreach (PropertyInfo property in propertyInfo.Where(x => x.CanWrite)
            {
               property.SetValue(objTarget, property.GetValue(objSource, null).InnerCloneObject(alreadyVisitedInstances));
            }
    		
    		
            return objTarget;
        }
    	
    	private static bool IsPrimitive(Type type)
        {
            return type == typeof(string) || type.IsPointer || (type.IsValueType && type.IsPrimitive);
        }
    }
