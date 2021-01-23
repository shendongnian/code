      private void button1_Click(object sender, EventArgs e)
            {
                Button button = (Button)sender;
    
                button.Width = button.Width + 10;
                button.Height = button.Height + 10;
    
                button.Location = new Point(button.Location.X + 10, button.Location.Y + 10);
    
            }
