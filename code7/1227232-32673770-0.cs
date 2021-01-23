    using (StreamReader read2 = File.OpenText("save" + campionatoselezTxt.Text + "bex.txt"))
	{
		using (StreamWriter write2 = File.CreateText("read" + campionatoselezTxt.Text + "bex.txt"))
		{
			int k = 0;
			string newLine = string.Empty;
			while (!read2.EndOfStream)
			{
				if (k == 8)
				{
					write2.WriteLine(newLine);
					k = 0;
					newLine = string.Empty;
				}
				newLine = string.IsNullOrEmpty(newLine) ? read2.ReadLine() : newLine + ";" + read2.ReadLine();
				k++;
				if (newLine.Contains("Betting"))
				{
					write2.WriteLine(newLine.Substring(0, newLine.IndexOf("Betting")));
					break;
				}
			}
		}
	}
