    public Form1()
    {
        InitializeComponent();
        int row = 1; // number of rows
        int col = 2; // number of columns (change them to see effect)
        var grids = new DataGridView[row,col];
        // create rows and set their height
        t.RowCount = row;        
        foreach (RowStyle style in t.RowStyles)
        {
            style.SizeType = SizeType.Percent;
            style.Height =(float)(1.0 / row);
        }
        // create columns and set their width
        t.ColumnCount = col;
        foreach (ColumnStyle style in t.ColumnStyles)
        {
            style.SizeType = SizeType.Percent;
            style.Width = (float)(1.0 / col);
        }
        // dynamically add grid in necessary place in layout
        for(int r = 0; r<row; r++)
            for (int c = 0; c < col; c++)
            {
                grids[r,c] = new DataGridView();
                t.Controls.Add(grids[r, c], c, r);
            }
    }
