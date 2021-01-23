    private string _address = null;
    private void button1_Click(object sender, EventArgs e)
    {
        // do other stuff
        _address = "http://www.watchcartoononline.com/anime/ai-yori-aoshi-guide";
    }
    private void button2_Click(object sender, EventArgs e)
    {
        // do other stuff
        _address = "http://www.watchcartoononline.com/anime/ai-yori-aoshi-enishi-guide";
    }
    private void button3_Click(object sender, EventArgs e)
    {
        if (_address != null)
        {
            audio.Stop();
            if (button1.Enabled || button2.Enabled)
            {
                timer1.Stop();
                pictureBox1.Visible = false;
                System.Diagnostics.Process.Start(_address);
            }
        }
    } 
