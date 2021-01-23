    private void numericUpDown1_ValueChanged(object sender, EventArgs e)
    {
		var buttons = new [] { button1, button2, button3, button4, };
		for (var i = 0; i < buttons.Length; i++)
		{
			buttons[i].Visible = numericUpDown1.Value - 1 >= i
		}
    }
