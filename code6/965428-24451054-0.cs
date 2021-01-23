    public static class PlanExtension
    {
      PropertyInfo _info = typeof(Plan).GetProperties();
    
      public static void SetValue(this Plan plan, int index, int value)
      {
        var prop = _info[index - 1]; // So 1 maps to 0.. or 1 in this case
        prop.SetValue(plan, value, null);
      }
    
      public static int GetValue(this Plan plan, int index)
      {
        var prop = _info[index - 1]; // Mapping magic
        return (int) prop.GetValue(plan, null);
      }
    }
