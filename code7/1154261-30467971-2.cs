    public static class EnumExtensions
    {
        public static string GetDisplayAttributeFrom(this Enum enumValue, Type enumType)
        {
            string displayName = "";
            MemberInfo info = enumType.GetMember(enumValue.ToString()).First();
            if (info != null && info.CustomAttributes.Any())
            {
                DisplayAttribute nameAttr = info.GetCustomAttribute<DisplayAttribute>();
                
                if(nameAttr != null) 
                {
                    // Check for localization
                    if(nameAttr.ResourceType != null && nameAttr.Name != null)
                    {
                        // I recommend not newing this up every time for performance
                        // but rather use a global instance or pass one in
                        var manager = ResourceManager("ResFileName", ResFileAssembly);
                        displayName = manager.getString(nameAttr.Name)
                    }
                    else if (nameAttr.Name != null)
                    {
                        displayName = nameAttr != null ? nameAttr.Name : enumValue.ToString();
                    }
                }
            }
            else
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
