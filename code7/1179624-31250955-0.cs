    private void button2_Click(object sender, EventArgs e)
    {
    
        Excel.Worksheet sht = app.ActiveSheet;
        Excel.PivotTable pt = sht.PivotTables(1);
        Excel.PivotField pf = pt.PivotFields("DATE");
    
        Excel.Range rng = pf.DataRange;
    
        Excel.Range cell = rng.Cells[1];
        cell.Group(true, true, Type.Missing, new bool[] { false, false, false, false, true, true, false });
    }
