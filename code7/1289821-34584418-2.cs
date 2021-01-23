    Rectangle box = new Rectangle(113, 113, 276, 276);
    char direction;
    Point temp;
    
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using (Graphics g = this.CreateGraphics())
        {
            Pen pen = new Pen(Color.Black, 2);
            g.DrawRectangle(pen, box);
            pen.Dispose();
        }
    }
    
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        temp = new Point(e.Location.X, e.Location.Y);    
        if (box.Contains(temp.X, temp.Y))
        {
            textBox1.Text = temp.X + " , " + temp.Y;
        }
        else
        {
            //COMMENT OUT THIS LINE FOR MOVEMENTS OUTSIDE THE Box
            if (textBox1.Text.Length == 1) return;
    
            if (box.Left >= temp.X)
            {
                direction = 'w';
            }
            else if (box.Left + box.Width <= temp.X)
            {
                direction = 'e';
            }
            else if (box.Top >= temp.Y)
            {
                direction = 'n';
            }
    
            else if (box.Top + box.Height <= temp.Y)
            {
                direction = 's';
            }
    
            textBox1.Text = direction.ToString();
        }
    }
