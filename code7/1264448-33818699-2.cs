	textBox1.Clear();
	textBox2.Text = textBox2.Text.Replace(" ", "");
	string StrValue = "";
	while (textBox2.Text.Length > 0)
	{
		StrValue += System.Convert.ToChar(System.Convert.ToUInt32(textBox2.Text.Substring(0, 2), 16)).ToString();
		textBox2.Text = textBox2.Text.Substring(2, textBox2.Text.Length - 2);             
	}
    textBox1.Text = StrValue;
