    private void button1_Click(object sender, EventArgs e)
    {
        this.Capture = true;
    }
    private void MouseCaptureForm_MouseDown(object sender, MouseEventArgs e)
    {
            
        MessageBox.Show(this.PointToScreen(new Point(e.X, e.Y)).ToString());
    }
