    private KeyboardFilter kbFilter;
        
    private void MainForm_Activated(object sender, EventArgs e)
    {
    	kbFilter = new KeyboardFilter(new Keys[] 
    	{ 
    		Keys.LWin | Keys.D,
    		Keys.RWin | Keys.D,
    		Keys.LWin | Keys.X, // if you need
    		Keys.RWin | Keys.X, // if you need
    		Keys.Alt  | Keys.F4  // if you need
    	});
    }
    		
    private void MainForm_Deactivate(object sender, EventArgs e)
    {
    	kbFilter.Dispose();
    }
