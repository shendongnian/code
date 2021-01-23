    // Don't forget the using in your imports and such
    using System.Diagnostics;
    
    Stopwatch stopwatch = new Stopwatch();
    
    public void CheckTime()
    {
    	label1.Text = stopwatch.Elapsed.ToString("hh\\:mm\\:ss\\:ff");
    }
    
    public void timer_Tick(object sender, EventArgs e)
    {
    	CheckTime();
    }
