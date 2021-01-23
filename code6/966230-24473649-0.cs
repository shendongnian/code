    private void Button_MouseEnter(object sender, MouseEventArgs e)
    {
    	new Thread(HideMouse).Start();
    }
    
    private void Button_MouseLeave(object sender, MouseEventArgs e)
    {
    	stopHiding.Set();
    	System.Windows.Forms.Cursor.Show();
    }
    
    private AutoResetEvent stopHiding = new AutoResetEvent(false);
    
    private void HideMouse()
    {
    	if (!stopHiding.WaitOne(2000))
    	{
    		Dispatcher.BeginInvoke(new Action(() => System.Windows.Forms.Cursor.Hide()));
    	}
    }
