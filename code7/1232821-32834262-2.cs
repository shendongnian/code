    private Button[,] _grid1;
    private Button[,] _grid2;
    public UserForm()
    {
        InitializeComponent();
        _grid1 = new Button[10, 10];
        _grid2 = new Button[10, 10];
        CreateGrid(_grid1, 10, 10, 25, 0, 20, true);
        CreateGrid(_grid2, 10, 10, 25, 250, 20, false);
    }
    public void CreateGrid(Button[,] grid, int numOfRows, int numOfCols, int offsetX, int offsetY, int buttonSize, bool enabled)
    {
        for (byte i = 0; i < numOfRows; i++)
        {
            for (byte j = 0; j < numOfCols; j++)
            {
                grid[i,j] = ButtonCreator(i, j, offsetX, offsetY, buttonSize, enabled);
            }
        }
    }
    public Button ButtonCreator(int row, int col, int x, int y, int buttonSize, bool enabled)
    {
        Button btn = new Button();
        btn.Size = new Size(buttonSize, buttonSize);
        btn.Location = new Point(x + (col * buttonSize), y + (row * buttonSize));
        btn.Font = new Font("Georiga", 10);
        this.Controls.Add(btn);
        btn.Click += new EventHandler(btn_Click);
        btn.Tag = row + "," + col;
        btn.Enabled = enabled;
        return btn;
    }
    void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string[] coord = btn.Tag.ToString().Split(',');
        int curRow = Convert.ToInt32(coord[0]);
        int curCol = Convert.ToInt32(coord[1]);
        
        Console.WriteLine(curRow = " + curRow + ", curCol = " + curCol);
        // ... now you can use "curRow", "curCol" to do something ...
        _grid1[curRow, curCol].BackColor = Color.Red;
    }
