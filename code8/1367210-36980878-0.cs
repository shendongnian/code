    public IEnumerable<object[]> GetValues(IList<string> columns, DataTable dt) {
      foreach (var row in dt.Rows) {
        var rowResult = new object[columns.Count];
        for (var col = 0; col < columns.Count; col++) {
          rowResult[col] = row.Item[columns[col]];
        }
        yield return rowResult;
      }
    }
