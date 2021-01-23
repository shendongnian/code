    var arrayE = new[]
    {
        new[] {txtSchoolN1, txtDegree1, txtStartD1, txtEndD1},
        new[] {txtSchoolN2, txtDegree2, txtStartD2, txtEndD2},
        new[] {txtSchoolN3, txtDegree3, txtStartD3, txtEndD3},
        new[] {txtSchoolN4, txtDegree4, txtStartD4, txtEndD4},
        new[] {txtSchoolN5, txtDegree5, txtStartD5, txtEndD5},
        new[] {txtSchoolN6, txtDegree6, txtStartD6, txtEndD6}
    };
    for (var x = 0; x < dataTable.Rows.Count; x++)
    {
        arrayE[x][0].Text = dataTable.Rows[x][0].ToString().Trim();
        arrayE[x][1].Text = dataTable.Rows[x][1].ToString().Trim();
        arrayE[x][2].Text = dataTable.Rows[x][2].ToString().Trim();
        arrayE[x][3].Text = dataTable.Rows[x][3].ToString().Trim();
    }
