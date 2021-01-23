    private object LoadPercentDiffPoP(String TopOrBottomPercent, DateTime prevPeriodStart, DateTime prevPeriodEnd, DateTime currPeriodStart, DateTime currPeriodEnd) {
      ...
      // Populating data from dictionary to grid
      IEnumerable<KeyValuePair<string, ReportData>> query = ReportDataElements;
      if (TopOrBottomPercent.ToLower() == "top") {
        query = query
          .Where(kvp => kvp.Value.CommPercentDiff > 0)
          .OrderByDescending(P => P.Value.CommPercentDiff);
      } else {
        query = query
          .Where(kvp => kvp.Value.CommPercentDiff < 0 && kvp.Value.CommPercentDiff >= Convert.ToDecimal(maxPercentDisplayed))
          .OrderBy(P => P.Value.CommPercentDiff);
      }
      foreach (KeyValuePair<string, ReportData> keyValuePair in query.Take(itemsToReturn)) {
        detailTable.Rows.Add(new object[]{
          keyValuePair.Value.LocationVar,
          keyValuePair.Value.PropertyID,
          keyValuePair.Value.Property,
          keyValuePair.Value.IndividualID,
          keyValuePair.Value.Individual,
          keyValuePair.Value.PrevPeriodComm,
          keyValuePair.Value.CurrPeriodComm,
          keyValuePair.Value.CommPercentDiff
        });
      }
      return detailTable;
    }
