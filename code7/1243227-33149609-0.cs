    PropertyInfo[] props = typeof(instanceOfMyClass).GetProperties();
    foreach (PropertyInfo prop in props)
    {
         object[] attrs = prop.GetCustomAttributes(true);
         foreach (object attr in attrs)
         {
               var sensitive = attr as SensitiveDataAttribute;
               if (sensitive != null)
               {
                   //add the default value to your property here
                  prop.SetValue(instanceOfMyClass, "Default Value", null);
              }
         }
    }
