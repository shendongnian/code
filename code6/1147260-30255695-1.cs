     public DragLabel()
     {
         //..
         MouseDown += DragLabel_MouseDown;
         MouseMove += DragLabel_MouseMove;
         MouseUp += DragLabel_MouseUp;
     }
     Point mDown { get; set; }
     //Point mCur { get; set; }  // optional: current position
     void DragLabel_MouseDown(object sender, MouseEventArgs e)
     {
          mDown = e.Location;
     }
     void DragLabel_MouseMove(object sender, MouseEventArgs e)
     {
          if (e.Button == MouseButtons.Left)
          {
               Location = new Point(e.X + Left - mDown.X, e.Y + Top - mDown.Y);
               // mCur = Location;
          }
     }
     void DragLabel_MouseUp(object sender, MouseEventArgs e)
     {
          mDown = Point.Empty;
     }
