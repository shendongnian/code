    for (int col = 0; col < GridView1.HeaderRow.Controls.Count; col++)
    {
        TableCell tc = GridView1.HeaderRow.Cells[col];
        tc.Style.Add("color", "#FFFFFF");
        tc.Style.Add("background-color", "#444");
    }
