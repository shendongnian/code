    private void button1_Click_1(object sender, EventArgs e)
    {
        var r = new System.Random();
        var i = 0;
        while (i < 1000)
        {
            textBox1.Text = r.Next(0, 1000).ToString();
            i++;
        }
    }
    
