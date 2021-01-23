    static string MyReplace(string dirty, char separator)
    {
		string newText = "";
		bool replace = false;
		for (int i = 0; i < dirty.Length; i++)
		{
			if(dirty[i] == separator) { replace = !replace ; continue;}
			if(replace ) continue;
			newText += dirty[i];
		}
		return newText;
    }
    
    richTextBox2.Text = MyReplace(richTextBox2.Text, ':');
