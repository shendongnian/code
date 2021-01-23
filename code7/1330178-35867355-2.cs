    private void button1_Click(object sender, EventArgs e)
    {
        var textOne = textBox1.Text,
            textTwo = textBox2.Text;
        if (textOne == "x" && textTwo == "123")
        {
            Hide();
            using(var fr1 = new Form1())
            {
                fr1.ShowDialog();
            }
        }
        else if (textOne == "z" && textTwo == "t")
        {
            Hide();
            using(var fr1 = new Form1(true))
            {
                fr1.ShowDialog();
            }
        }
    }
