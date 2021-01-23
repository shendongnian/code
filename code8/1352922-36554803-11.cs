    private var pictureGrid = new PictureBox[8, 8];    
    private Dictionary<int, Bitmap> colors = new  Dictionary<int, Bitmap>();
    
    private void Load() 
    {
        Bitmap White = Properties.Resources.white;
        Bitmap Black = Properties.Resources.black;
        Bitmap None = Properties.Resources.none;
    
    	colors.Add(1, White);
    	colors.Add(-1, Black);
    	colors.Add(0, None);
    }
    
    private void Draw()
    {
        for (int r = 0; r <= grid.GetUpperBound(0); r++)
        {
            for (int c = 0; c <= grid.GetUpperBound(0); c++)
            {
                if (pictureGrid[r, c] != null) 
                {
                    pictureGrid[r,c].Image = colors[grid[r,c]];
                }
    
                else 
                {
                    var picbox = new PictureBox()
                    {
                        Name = grid[r, c].name,
                        Size = new Size(64, 64),
                        Location = new Point(r * 65 + 15, c * 65 + 60),
                        Text = grid[r, c].name,
                        Image = colors[grid[r,c]]
                     };
    				
    				pictureGrid[r,c] = picbox;
                    Controls.Add(picbox);
                    picbox.Click += ClickBox;
                    MessageBox.Show("black draw" + grid[r, c].name);
    
                }
    
            }
        }
    }
