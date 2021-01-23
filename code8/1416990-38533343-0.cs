    private void btnLayout_Click(object sender, EventArgs e)
            {
                Form form = new Form();
    
                form.Text = "Design";
    
                form.Show();
    
                using (Graphics g = form.CreateGraphics())
                {
                    Pen pen = new Pen(Color.Black, 2);
                    Brush brush = new SolidBrush(Color.AliceBlue);
    
                    g.DrawRectangle(pen, 100, 100, 100, 200);
    
                    pen.Dispose();
                }
    }
