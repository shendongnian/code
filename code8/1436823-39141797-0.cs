    private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.ParseExact(textBox1.Text, "HH:mm", System.Globalization.CultureInfo.CurrentCulture);
            TimeSpan time = new TimeSpan(8,40,0);
            DateTime outputTime = dateTime.Add(time);
            textBox2.Text = outputTime.ToString("HH:mm");
        }
