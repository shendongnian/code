	if(int.TryParse(Text1, out Int1) &&  int.TryParse(Text2, out Int2))
	{        
		Product = Int1 * Int2;
		listBox1.Items.Add(textBox1.Text);
		listBox1.Items.Add(textBox2.Text);
		listBox1.Items.Add(Product);
	}
