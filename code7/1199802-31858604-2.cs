       public List<string > GetChangedProperties(object obj1,object obj2)
            {
 
               if (obj1.GetType() != obj2.GetType())
                    throw new InvalidOperationException("Two objects should be from the same type");
                List<string> result = new List<string>();
    
                var properties = obj1.GetType().GetProperties();
                foreach (var property in properties)
                {
                    if(property.GetValue(obj1) != property.GetValue(obj2))
                    {
                        result.Add(property.Name);
                    }
                }
    
                return result;
    
            }
