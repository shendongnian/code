    void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
    {
       if (e.CellElement.ColumnInfo.Name == "unitprice")
       {
        dataCell.ForeColor = System.Drawing.Color.Blue;
        dataCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
       }
    }
