    class Block
        {
            Panel Screen;
            PictureBox Box;
            Point _x;
            Size s = new Size(50, 50);
            Color c = Color.FromName("black");
    
           //Pass the position x to the block
            public Block(Point x)
            {
                _x = x;
                Screen = new Panel
                {
                    Size = s
                };
            }
            public Panel _ScreenPanel()
            {
                Screen.Location = _x;
                return Screen;
            }
    
            public void  SpawnBlock()
            {
                Box = new PictureBox
                {
                    Dock = DockStyle.Fill,
                    Name = "Obstacle" + _x,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = c
                };
               Screen.Controls.Add(Box);
            }
        }
