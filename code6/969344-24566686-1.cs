    Keys key1 = Keys.None;
    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
    	if (key1 == Keys.H && e.Modifiers == Keys.Control && e.KeyCode != Keys.ControlKey)
    	{
    		MessageBox.Show("Key Pressed");
    		key1 = Keys.None;
    	}
    	else if (e.Control && key1 == Keys.None && e.KeyCode != Keys.ControlKey)
    		key1 = e.KeyCode;
    	else if (e.Control)
    		key1 = Keys.None;
    }
