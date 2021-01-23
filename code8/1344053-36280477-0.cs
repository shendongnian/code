    lastPoint = null;
    private void userControl_MouseClick(object sender, MouseEventArgs e) {
    
      if (e.Button == MouseButtons.Left)
      {
        Point newPoint = e.Location;
        if(lastPoint != null)
        {
          drawLine(lastPoint, newPoint);
        }
        lastPoint = newPoint;
    
      }
    }
