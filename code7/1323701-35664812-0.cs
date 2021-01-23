    private void button1_Click_1(object sender, EventArgs e)
    {
        var r = new System.Random();
        
        for (var i = 0; i < 1000; i++)
        {
            textBox1.Text = r.Next(0, 1000).ToString();
        }
    }
