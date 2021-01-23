    private void button4_Click(object sender, EventArgs e)
    {
        int R, I;
 
        if (int.TryParse(textBox1.Text, out R) &&
            int.TryParse(textBox2.Text, out I))
        {
             int E = R - I;
             textBox3.Text = E.ToString(); 
        }
        else 
        {
           MessageBox.Show("You have entered an invalid value!");
        }
    }
