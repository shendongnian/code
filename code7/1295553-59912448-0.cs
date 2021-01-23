    ...
    _myPictureBox.MouseEnter += new EventHandler(myPictureBox_MouseEnter);
    _myPictureBox.MouseLeave += new EventHandler(myPictureBox_MouseLeave);
    _myPictureBox.KeyDown += new KeyEventHandler(myPictureBox_event_KeyDown);
    ...
    private void myPictureBox_MouseEnter(object sender, EventArgs e)
    {
    	Focus();
    }
    private void myPictureBox_MouseLeave(object sender, EventArgs e)
    {
    	FindForm().ActiveControl = null;
    }
    private void myPictureBox_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.Delete)
    		MessageBox.Show("Bye");                
    }
