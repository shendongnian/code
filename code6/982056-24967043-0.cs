    var a = obj.GetType().GetProperty("inobjects").PropertyType.GetProperties();
    foreach (var item in a)
    {
         if (item.Name == PropertyName)
         {
             var test = obj.GetType().GetProperty("inobjects").GetValue(obj,null);
             s = (string)test.GetType().GetProperty(PropertyName).GetValue(test, null);
         }
    }
