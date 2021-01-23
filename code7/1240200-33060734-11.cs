        public void DoStuff(object obj)
        {
            PropertyInfo prop = obj.GetType().GetProperty("Prop1");
            if (prop != null && prop.PropertyType == typeof(bool) && prop.CanWrite)
            {
                prop.SetValue(obj, true);
            }
        }
