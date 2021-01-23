    while (db.Read()) {
      
      for (var colIdx = 0; colIdx < columnCount. ++colIdx) {
        if (!db.IsDbNll(colIdx)) {
          string value = db.GetString(colIdx);
          // Process value
        }
      }
    }
