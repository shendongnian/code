    public void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        initialTimeStamp = DateTime.Now.Ticks;
    }
    public void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
        timeStamp = DateTime.Now.Ticks;
        long elapsedTicks = timeStamp - initialTimeStamp;
        long timeStampInNanoseconds = elapsedTicks * 100;
    }
