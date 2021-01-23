    string sRng = string.Join(",", YourModel.Where(l => l.YourColumn.Length > 25)
        .Select(a => "A" + a.iRow)); // this address could be many pages and it works
    if (sRng.Length > 0) {
        ws.Cells[sRng].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green); 
    }
