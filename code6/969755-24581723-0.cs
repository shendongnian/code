            private void drawbox_MouseMove(object sender, MouseEventArgs e)
            {
    
                Point p = e.Location;
                Point formpoint = PointToClient(MousePosition);
                
                this.Text = formpoint.ToString() + " - " + p.ToString();
            }
    
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                this.Text = e.Location.ToString();
            }
