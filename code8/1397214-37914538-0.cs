    private async void button1_Click(object sender, EventArgs e)
    {
        if (textBox2.Text==("Tim The Enchanter") && textBox1.Text==("cave100"))
        {
            label2.Visible = true;
            label2.Text = ("Correct");
            label2.ForeColor = System.Drawing.Color.Green;
            await Task.Delay(1000);
            this.Hide();
            Form2 form2 = new Form2();
            form2.Visible = true;
        }
    }
