	public Form1()
	{
		InitializeComponent();
		string[] reader = File.ReadAllLines(@"F:\Bioshock2SP.ini");
		foreach (string lines in reader)
		{
			if (lines.Contains("VoVolume="))
			{
				lines = lines.Substring(lines.Length - 2);
				TextBox.Text = lines; //Exception
			}
		}	
	}
