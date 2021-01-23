    void main(){
        timer = new Timer();
        timer.Interval = 1000; // 1000 miliseconds = 1 second
        timer.Tick += new EventHandler(timer_Tick);
        timer.Enabled = true;
    }
    void timer_Tick(object sender, EventArgs e)
    {
        // Do what you need
        var clicks = _klicks;
        // method to save clicks to the file
        _klicks = 0;
        return clicks;
    }
