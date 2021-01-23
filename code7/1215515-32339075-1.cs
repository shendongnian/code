    int[] counter = { 0, 1, 2, 3 };
    for (int x = 0; x < dataTable.Rows.Count; x++) {
        for (int i = 0; i < counter.Length; i++) {
            arrayE[counter[i]].Text = dataTable.Rows[x][i].ToString().Trim();
            counter[i] += 4;
        }
    }
