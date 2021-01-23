    List<string> conditions = new List<string>();
    if (boatClass != "all" && !string.IsNullOrEmpty(boatClass))
      conditions.Add("[Class] = '" + boatClass + "'");
    if (boatYear != "all" && !string.IsNullOrEmpty(boatYear))
      conditions.Add("[Year] = " + boatYear);
    if (boatMake != "all" && !string.IsNullOrEmpty(boatMake))
      conditions.Add("[Make] = '" + boatMake + "'");
    if (boatUsedNew != "all" && !string.IsNullOrEmpty(boatUsedNew))
      conditions.Add("[UsedOrNew] = '" + boatUsedNew + "'");
    
    if (conditions.Count > 0)
      sql += " where " + strig.Join(" AND ", conditions);
