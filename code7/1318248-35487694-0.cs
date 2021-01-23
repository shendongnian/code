        private static void replaceFoobar(object obj)
        {
            if (obj == null)
                return;
            const BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.GetProperty | BindingFlags.Instance;
            FieldInfo[] members = obj.GetType().GetFields(bindingFlags);
            if (!members.Any())
                return;
            foreach (var item in members)
            {
                if (item.Name == "fooBar" || item.Name == "<fooBar>k__BackingField")
                {
                    item.SetValue(obj, "qwerty");
                }
                else
                {
                    object value = item.GetValue(obj);
                    
                    if (value != null && value is IEnumerable)
                    {
                        foreach (var itemE in ((IEnumerable)value))
                            replaceFoobar(itemE);
                    }
                    else
                        replaceFoobar(value);
                }
            }
        }
