    private String[] GetProperties(EContent_EcontentFields eContentField)
            {
                List<String> list = new List<String>();
                Type type = eContentField.GetType();
                var properties = type.GetProperties().Where(x => x.MemberType == MemberTypes.Property).Select(x => x.Name);
                foreach (var item in properties)
                {
                    if(item != null)
                        list.Add(item.ToString());
                }  
    
                return list.ToArray();
            }
