    private void button4_Click(object sender, EventArgs e)
    {
        int number1;
        int number2;
        if (int.TryParse(textBox1.Text, out number1) && int.TryParse(textBox2.Text, out number2))
        {
          //do your thang (subtraction, assigning the result to TextBox3)
          //return
        }
        else
        {
          MessageBox.Show("Oh no you entered something that's not an int!");
        }
    }
