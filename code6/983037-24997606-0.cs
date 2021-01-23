    static bool IsContinuous(IDictionary<string,string> dates) {
      DateTime? lastDate = null;
      foreach (var date in dates
        .Values
        .Select(d => DateTime.Parse(d))
        .OrderBy(d => d)) {
        if (lastDate.HasValue && (date - lastDate.Value).TotalDays != 1.0) {
          return false;
        }
        lastDate = date;
      }
      return true;
    }
