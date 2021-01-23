    void navBarControl1_MouseMove(object sender, MouseEventArgs e) {
       NavBarHitInfo hitInfo = navBarControl1.CalcHitInfo(new Point(e.X, e.Y));
       if (hitInfo.InGroup) {
          NavBarGroup group = hitInfo.Group;
          // perform operations on the group here
          //...
       }
    }
