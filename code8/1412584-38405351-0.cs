        public static string GetEnumDisplayName<T>(T enumInstance)
        {
            return GetDisplayName(enumInstance.GetType().GetField(opt.ToString()));
        }
        private static string GetDisplayName(FieldInfo field)
        {
            DisplayAttribute display = field.GetCustomAttribute<DisplayAttribute>(inherit: false);
            if (display != null)
            {
                string name = display.GetName();
                if (!String.IsNullOrEmpty(name))
                {
                    return name;
                }
            }
            return field.Name;
        }
