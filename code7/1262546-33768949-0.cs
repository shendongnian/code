    private void button6_Click(object sender, EventArgs e)
    {
        DateTime showTime = DateTime.Parse(textBox4.Text);
        TimeSpan duration = TimeSpan.Parse(textBox5.Text);
        movies.Add(new Movies(textBox1.Text, textBox2.Text, textBox3.Text,
            showTime.Hour, showTime.Minute, duration.Hours, duration.Minutes, 
        this.DisplayData();
    }
