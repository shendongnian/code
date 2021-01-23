    while (textBox2.Text.Length > 0)
    {
        string StrValue = System.Convert.ToChar(System.Convert.ToUInt32(textBox2.Text.Substring(0, 2), 16)).ToString();
        textBox2.Text = textBox2.Text.Substring(2, textBox2.Text.Length - 2);             
        textBox1.Text = textBox1.Text + StrValue + " ";
    }
