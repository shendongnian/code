    private void AddOne()
    {
        // create a new tablelayoutpanel
        // with 2 rows, 1 column
        var table = new TableLayoutPanel();
        table.RowCount = 2;
        table.RowStyles.Add(new RowStyle());
        table.RowStyles.Add(new RowStyle());
        table.ColumnCount = 1;
        table.Dock = DockStyle.Fill; // take all space
    
        // create a label, notice the Anchor setting
        var lbl = new Label();
        lbl.Text = "lorem ipsum\r\nnext line\r\nthree";
        lbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        lbl.AutoSize = true;
        // add to the first row
        table.Controls.Add(lbl, 0, 0);
    
        // create the picturebox
        var pict = new PictureBox();
        pict.Image = Bitmap.FromFile(@"demo.png");
        pict.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        pict.SizeMode = PictureBoxSizeMode.Zoom;
        // add to the second row
        table.Controls.Add(pict, 0, 1);
    
        //add the table to the main table that is on the form
        mainTable.Controls.Add(table, 0, mainTable.RowCount);
        // increase the rowcount...
        mainTable.RowCount++;
    
    }
