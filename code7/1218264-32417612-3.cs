    private void button1_Click(object sender, EventArgs e)
    {
        //Key Point to handle mouse events outside the form
        this.Capture = true;
    }
    private void MouseCaptureForm_MouseDown(object sender, MouseEventArgs e)
    {
        this.Activate();    
        MessageBox.Show(this.PointToScreen(new Point(e.X, e.Y)).ToString());
        
        //Cursor.Position works too as RexGrammer stated in his answer
        //MessageBox.Show(this.PointToScreen(Cursor.Position).ToString());
        
        //if you want form continue getting capture, Set this.Capture = true again here
        //this.Capture = true;
        //but all clicks are handled by form now 
        //and even for closing application you should
        //right click on task-bar icon and choose close.
    }
