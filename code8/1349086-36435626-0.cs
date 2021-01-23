    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        int sum = 0;
        float average = 0;
        sum += Convert.ToInt32(textBox1.Text);
        sum += Convert.ToInt32(textBox2.Text);
        sum += Convert.ToInt32(textBox3.Text);
        average = (float)sum / 3;
        textBox4.Text = average.ToString();
      }
      catch(FormatException exc)
      {
        textBox4.Text = "ERROR";
      }
    }
