	foreach (string[] str in items)
	{
		Control box = null;
		switch (str[4])
		{
			case "0":
				CustomControlTypeA a = CustomControlTypeA();
				a.richTextBox1.Rtf = str[5];
				box = a;
				break;
			case "1":
				CustomControlTypeB b = new CustomControlTypeB();
				b.panel1.BackgroundImage = Image.FromFile(str[5]);
				box = b;
				break;
		}
		box.Location = new Point(x, y);
		box.Width = w;
		box.Height = h;
		panelBody.Controls.Add(box);
		box.BringToFront();
	}
