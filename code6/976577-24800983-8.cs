    public class SearchModel
    {
        public object this[string propertyName] 
        {
            get{
               Type myType = typeof(MyClass);                   
               PropertyInfo myPropInfo = myType.GetProperty(propertyName);
               return myPropInfo.GetValue(this, null);
            }
            set{
               Type myType = typeof(SearchModel);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                switch (myPropInfo.PropertyType.Name)
                {
                    case "Int32":
                        myPropInfo.SetValue(this, Convert.ToInt32(value), null);
                        break;
                    case "Int64":
                        myPropInfo.SetValue(this, Convert.ToInt64(value), null);
                        break;
                    case "Boolean":
                        myPropInfo.SetValue(this, Convert.ToBoolean(value), null);
                        break;
                    case "DateTime":
                        myPropInfo.SetValue(this, Convert.ToDateTime(value), null);
                        break;
                    case "String":
                        myPropInfo.SetValue(this, value.ToString(), null);
                        break;
                    default:
                        myPropInfo.SetValue(this, value, null);
                        break;
                } 
            }
        }
    }
