    private void button1_Click(object sender, EventArgs e)
    { 
        textBox2.Clear();
        float result;
        if (float.TryParse(textBox1.Text, out result)
        {
             textBox2.AppendText(Math.Sin(result).ToString());
        }
        else
        {
            textBox2.Text = "Invalid Input";
        }
    }
