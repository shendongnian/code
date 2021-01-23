    for (int i = 3; i <= ws.Dimension.End.Row; i++)
    {
        GroupMembershipUploadInput gm = new GroupMembershipUploadInput();
        for (int j = ws.Dimension.Start.Column; j <= ws.Dimension.End.Column; j++)
        {
            var columnHeader = columnHeadersInOrder[j - ws.Dimension.Start.Column];
            var cellValue = ws.Cells[i, j].Value.ToString();
            MapFieldSetters[columnHeader](cellValue, gm);
        }
        gl.Add(gm);
    }
    
