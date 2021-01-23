    private void button4_Click(object sender, EventArgs e)
    {
        int R, I;
        if (int.TryParse(textBox1.Text, out R)
        && int.TryParse(textBox2.Text, out I))
        {
            int E = R - I;
            textBox3.Text = E.ToString(); 
        }
        else { textBox3.Text = ("value entered is not whole number"); }
    }
