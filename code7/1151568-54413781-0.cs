    void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)     
    {     
        if (e.CellElement.ColumnInfo is GridViewDataColumn)     
        {     
            if (((GridViewDataColumn)e.CellElement.ColumnInfo).FieldName == "City")     
            {     
                e.CellElement.DrawFill = true;     
                e.CellElement.NumberOfColors = 1;     
                e.CellElement.BackColor = System.Drawing.Color.Beige;     
            }     
        }     
    } 
