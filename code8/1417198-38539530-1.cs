    private async void btnCommit_Click(object sender, EventArgs e)
    {
        //do stuff
    
        Color c = new Color();
        for (int i = 0; i <= 255; i++)
        {
            c = Color.FromArgb(i, 255, i);
            textBox1.BackColor = c;
    
            await Task.Delay(10);
        }     
    }
