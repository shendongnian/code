    int currentRowIndex = 0;
    int actualRowIndex = databaseGridView.Rows.Count;
    for (int i = 0; i < completeInfoMatches.Count; i++) {
        var index = 0;
        if (actualRowIndex < completeInfoMatches.Count) {
             index = databaseGridView.Rows.Add();
        }
        databaseGridView.Rows[currentRowIndex].Cells[e.Node.Text.Replace(" ", string.Empty)].Value = completeInfoMatches[i].Groups[1].ToString();
        currentRowIndex = currentRowIndex + 1;
    }
