    public Form1()
    {
        InitializeComponent();
        int row = 1; // number of rows
        int col = 2; // number of columns (change them to see effect)
        var grids = new DataGridView[row,col];
        // create rows and set their height
        t.RowCount = row;            
        t.RowStyles.Clear();
        for (int r = 0; r < row; r++)
        {
            var style = new RowStyle();
            style.SizeType = SizeType.Percent;
            style.Height =(float)(1.0/row);
            t.RowStyles.Add(style);
        }
        // create columns and set their width
        t.ColumnCount = col;
        t.ColumnStyles.Clear();
        for (int c = 0; c < col; c++)
        {
            var style = new ColumnStyle();
            style.SizeType = SizeType.Percent;
            style.Width = (float)(1.0 / col);
            t.ColumnStyles.Add(style);
        }
        // dynamically add grid in necessary place in layout
        for(int r = 0; r<row; r++)
            for (int c = 0; c < col; c++)
            {
                grids[r,c] = new DataGridView()
                    {
                        Dock = DockStyle.Fill,
                    };
                t.Controls.Add(grids[r, c], c, r);
            }
    }
