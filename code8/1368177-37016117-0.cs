    private void Form1_Load(object sender, EventArgs e)
    {
      for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j <= 5; j++)
            {
                PictureBox tile = new PictureBox() ;
                tile.Size = new Size(49, 49);
                tile.BackColor = Color.Firebrick;
                tile.Location = new Point((100 + (50 * i)), (100 + (50 * j)));
                Debug.WriteLine("PB created with index ["+i+","+j+"]");
                
                Controls.Add(tile);
            }
        }
    }
