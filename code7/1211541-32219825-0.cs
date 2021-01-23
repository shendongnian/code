     using System.Reflection;
     ...
     // Let's check public properties that can be read and written (i.e. changed)
     var props = typeof(Car)
        .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        .Where(prop => prop.CanRead && prop.CanWrite);
      foreach (var property in props) {
        Object oldValue = property.GetValue(oldCar);
        Object newValue = property.GetValue(newCar);
        if (Object.Equals(oldValue, newValue)) 
          Console.WriteLine(String.Format("{0}: {1} -> {2}", 
            property.Name, 
            oldValue, 
            newValue)); 
      }
