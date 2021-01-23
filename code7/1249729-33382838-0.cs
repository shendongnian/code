    string value = string.Empty;
    int num;
    
    for (int i = 0; i < Gridview1.Rows.Count; i++ )
    {                
        // Cells 2 + i == Rows.If you are wondering why start with 2
        // Your 1st rows is Title so 2nd row is the value
        // Cells 2 == Column. Make sure your column is fix
        value = ws.Cells[2 + i, 2].Value + ""; // You can use .ToString().If you confirm is not null
        // Parse
        int.TryParse(value, out num);
        // Check
        if (num >= 1 && num <= 11)
            ws.Cells[2 + i, 2].Style.Font.Color.SetColor(System.Drawing.Color.Green);
        else if (num >= 12 && num <= 39)
            ws.Cells[2 + i, 2].Style.Font.Color.SetColor(System.Drawing.Color.Orange);
    }
