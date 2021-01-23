    bool AreEquals(object a, object b)
    {
      if (a == null && b == null) return true;
      if (a == null || b == null) return false;      
      var typeA = a.GetType();
      var typeB = b.GetType();
      if (typeA.Equals(typeB)) return a.Equals(b);
      var fieldsA = typeA.GetFields().Where(field => field.IsPublic).ToArray();
      var fieldsB = typeB.GetFields().Where(field => field.IsPublic).ToArray();
      if (fieldsA.Length != fieldsB.Length) return false;
      
      foreach(var field in fieldsA)
      {
         var other = fieldsB.FirstOrDefault(f => f.FieldType.Equals(field.FieldType) && f.Name.Equals(field.Name));
         if (other == null) return false;
         
         if (!field.GetValue(a).Equals(other.GetValue(b))) return false;  
      }
      return true;
    }
