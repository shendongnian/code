    timer = new Timer(16); //~60 FPS
	timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
    ...
    private void button1_MouseEnter(object sender, EventArgs e)
    {
        pictureBox1.Size = new Size(0, 145);
        pictureBox1.Show();
	    timer.Enabled = true; // Enable it
    }
    ...
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
	    if (pictureBox1.Width < 290)
            pictureBox1.Width++; //Increment
        else
            timer.Enabled = false; //Disable
    }
