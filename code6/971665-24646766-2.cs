	List<string> texts = new List<string>{textbox1.Text, textbox2.Text};
	int sum = 0;
	foreach(string t in texts)
	{
		int parse = 0;
		if(!int.TryParse(t, out parse))
			//Not a valid number
		sum += parse;	
	}
    textbox11.Text = sum.ToString();
