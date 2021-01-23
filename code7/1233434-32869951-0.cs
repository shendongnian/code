	string text; // declare it here
	if (radioButton2.Checked) 
	{
		text = Properties.Resources.bindyes; 
	}
	else if (radioButton1.Checked)
	{
		text = Properties.Resources.bindno;   
	}
	
	File.WriteAllText("C:\\Users\\Karl\\Desktop\\downloader.bat", text);
