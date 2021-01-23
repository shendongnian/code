    bool Compare(DataColumn[] primary, DataColumn[] secondary)
    {
      if (primary.Length != secondary.Length) return false;
      var names = new HashSet<string>(secondary.Select(col => col.ColumnName));
      
      return primary.All(col => names.Contains(col.ColumnName));
    }
