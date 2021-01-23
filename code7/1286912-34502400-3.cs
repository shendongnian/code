     for (int i = 0; i < 4; i++)
        {
            for (int y = 0; y < 4; y++)
            {
                Rectangle r = new Rectangle(i*(pictureBox1.Image.Width / 4), 
                                            y*(pictureBox1.Image.Height / 4), 
                                            pictureBox1.Image.Width / 4, 
                                            pictureBox1.Image.Height / 4);
    
                g.DrawRectangle(pen,r );
    
                list.Add(cropImage(pictureBox1.Image, r));
            }
        }
