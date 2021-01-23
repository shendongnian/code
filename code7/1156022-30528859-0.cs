    private static bool IsEqual(Model1 model, Model2 model2)
    {
      long changes = 0;
      foreach (var pi in typeof(Model1).GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        var secondModelPi = typeof(Model2).GetProperty(pi.Name, BindingFlags.Instance | BindingFlags.Public);
        if (secondModelPi != null)
        {
          if (!pi.GetValue(model).Equals(secondModelPi.GetValue(model2)))
          {
            changes++;
          }
        }
      }
      return changes == 0;
    }
