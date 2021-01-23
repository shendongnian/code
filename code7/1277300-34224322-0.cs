        public static void PopulateInto(
            this object source,
            object target,
            BindingFlags flags)
        {
            foreach (var pi in source.GetType().GetProperties(flags))
            {
                var tpi = target.GetProperty(pi.Name, flags);
                if (tpi.IsNotNull())
                {
                    try
                    {
                        object originalValue;
                        object value = originalValue = source.GetValue<object>(pi.Name, new object[0], flags);
                        try
                        {
                            value = Convert.ChangeType(originalValue, tpi.PropertyType);
                        }
                        catch
                        {
                        }
                        tpi.SetValue(target, value, new object[0]);
                    }
                    catch
                    {
                    }
                }
            }
        }
