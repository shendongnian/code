            x = PictureBox1.Location.X;
            y = pictureBox1.Location.Y;
            for (int i = 0; i < 361; i++)
                {
                    board[i] = new Label();
                    board[i].Parent = pictureBox1;
                    board[i].Location = new Point(x,y); 
                    board[i].Name = "label" + i;    
                    board[i].Text = "0";
                    board[i].BackColor = Color.Black;
                    board[i].Size = new Size(10,10); //Define size of label according to your choice 
                    if(x >= 1024)
                    {
                      x = PictureBox1.Location.X; //Start position
                      y += 55;                    // Step to next line
                    }
                    else
                      x += 55;                   //jump to next horizontal box
                }
