        public static string GetClassName(Type cls)
        {
            if (cls.IsGenericType)
            {
                var param = string.Join(",", cls.GetGenericArguments().Select(v => GetClassName(v)).ToArray());
                return cls.Name.Split('`')[0] + "<" + param + ">";
            }
            else
            {
                return cls.Name;
            }
        }
