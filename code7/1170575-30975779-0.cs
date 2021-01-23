    void PrintOutProperties(object OType)
    {
      foreach (System.Reflection.PropertyInfo prop in OType.GetType().GetProperties())
      {
          Response.Write(prop.Name + "<BR>")
      } 
    }
