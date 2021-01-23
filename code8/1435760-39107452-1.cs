    using System.Reflection;
    public static Dictionary<string, string> GetPropertiesValue(object o)
        {
            Dictionary<string, string> PropertiesDictionaryToReturn = new Dictionary<string, string>();
            
            foreach (MemberInfo itemMemberInfo in o.GetType().GetMembers())
            {
                if (itemMemberInfo.MemberType == MemberTypes.Property)
                {
                    //object PropValue = GetPropertyValue(OPSOP, item.Name);
                    //string itemProperty = itemMemberInfo.Name;
                    //string itemPropertyValue = o.GetType().GetProperty(itemMemberInfo.Name).GetValue(o, null).ToString();
                    //Console.WriteLine(itemProperty + " : " + itemPropertyValue);
                    PropertiesDictionaryToReturn.Add(itemMemberInfo.Name, o.GetType().GetProperty(itemMemberInfo.Name).GetValue(o, null).ToString());
                }
            }
            return PropertiesDictionaryToReturn;
        }
