       public static T Merge<T>(T source, T destination)
         {
             var returnvalue = (T) Activator.CreateInstance(typeof (T));
             foreach (var field in destination.GetType().GetProperties())
             {
                 field.SetValue(returnvalue,
                     field.GetValue(destination, null) == null ? field.GetValue(source) : field.GetValue(destination));
             }
             return returnvalue;
         }
