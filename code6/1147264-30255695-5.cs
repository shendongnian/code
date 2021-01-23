     public DragLabel()
     {
         //..
         MouseDown += DragLabel_MouseDown;
         MouseMove += DragLabel_MouseMove;
     }
     Point mDown { get; set; }
     void DragLabel_MouseDown(object sender, MouseEventArgs e)
     {
          mDown = e.Location;
     }
     void DragLabel_MouseMove(object sender, MouseEventArgs e)
     {
          if (e.Button == MouseButtons.Left)
          {
               Location = new Point(e.X + Left - mDown.X, e.Y + Top - mDown.Y);
          }
     }
