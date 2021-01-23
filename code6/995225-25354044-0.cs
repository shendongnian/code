     e.RowElement.DrawFill = true;
    void grid_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
    {
         if   (e.RowElement.RowInfo.Cells["CODE"].Value.ToString() == "something"))
                {   
                     e.RowElement.DrawFill = true;  
                     e.RowElement.BackColor = System.Drawing.Color.somecolor;
                }
     }
