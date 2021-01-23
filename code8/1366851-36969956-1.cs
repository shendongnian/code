    private void button1_Click(object sender, EventArgs e)
    {
        int number;
        if (!int.TryParse(textBox1.Text, out number))
        {
            MessageBox.Show("Could not convert user input to an int value");
            return;
        }
        try
        {
            List<int> binaryDigits = DecimalToBinary(number, 8);
            label3.Text = string.Join("", binaryDigits);
        }
        catch (ArgumentOutOfRangeException e1)
        {
            MessageBox.Show("Exception: " + e1.Message, "Could not convert to binary");
        }
    }
