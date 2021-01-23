    public class ChildControls
    {
            static public List<PropertyInfo> getPropertiesInfo(object myobject, bool considerReadWriteAttributes, bool canRead = true, bool canWrite = true)
            {
                List<PropertyInfo> objectPropertiesInfo;
    			var myType = object.GetType();
    
                if(considerReadWriteAttributes)
                    objectPropertiesInfo = myType.GetProperties().Where(p => (p.CanRead == canRead) && (p.CanWrite == canWrite) && p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0).ToList();
                else
                    objectPropertiesInfo = myType.GetProperties().Where(p => p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0).ToList();
    
                return objectPropertiesInfo;
            }
    		static public List<T> GetLogicalChildrenByProperty<T>(DependencyObject p_vParent, string propertyName, object propertyValue)
            {
                //create empty list of items of type T control
                List<T> childControlsList = new List<T>();
                List<object> childControls;
    
                //Get all child controls of a parent 
                childControls = LogicalTreeHelper.GetChildren(p_vParent).Cast<object>().ToList();
    
                //Loop through list of child controls and if child is required Type Control and its property value equal to givenValue then add to new list and set some of its properties            
                foreach (object obj in childControls)
                {
                    if (obj.GetType() == typeof(T) || obj is T)
                    {
                        bool shouldAdd = false;
                        T t = (T)obj;
    
                        if (propertyName != null && t != null)
                        {
                            var controlPropertiesInfo = Collections.getPropertiesInfo(obj, false, true, true);
                            var controlGivenPropertyInfo = controlPropertiesInfo.SingleOrDefault(d => d.Name == propertyName);
    
                            if (controlGivenPropertyInfo != null)
                            {
                                var controlGivenPropertyValue = controlGivenPropertyInfo.GetValue(obj);
    
                                if (controlGivenPropertyValue == popertyValue)
                                    shouldAdd = true;
                            }
                        }
    
                        if (shouldAdd)
                            childControlsList.Add(t);
                    }
                }
    
                return childControlsList;
            }
    } 
