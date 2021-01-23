    CustomButton[,] btn = new CustomButton[12, 12];
    public Main()
    {
        InitializeComponent();
        for (int x = 0; x < 12; x++)
        {
            for (int y = 0; y < 12; y++)
            {
                btn[x, y] = new CustomButton();
                btn[x, y].X = x;
                btn[x, y].Y = y;
                btn[x, y].SetBounds(25 * x, 25 * y + 30, 25, 25);
                btn[x, y].Click += new EventHandler(this.btnEvent_Click);
                Controls.Add(btn[x, y]);
            }
        }
    }
    void btnEvent_Click(object sender, EventArgs e)
    {
         var button = sender as CustomButton;
         Debug.WriteLine("X: {0} Y: {1}", button.X, button.Y); 
    }
