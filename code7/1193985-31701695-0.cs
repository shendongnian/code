    void navBarControl1_MouseMove(object sender, MouseEventArgs e) {
       NavBarHitInfo hitInfo = navBarControl1.CalcHitInfo(e.Location);
       if (hitInfo.InGroup) {
          NavBarGroup group = hitInfo.Group;
          // perform operations on the group here
          group.Expanded = true;  //Expand then group or you custom logic
       }
    }
