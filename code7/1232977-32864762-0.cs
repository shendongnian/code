	private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
	{
		CheckBox cb = sender as CheckBox;
		SetAllItemsChecked(cb.Checked);
		var installerLines = ReadInstallerLines();
		SetAllProductsChecked(installerLines.ToList(), cb.Checked);
		SaveInstaller(installerLines);
	}
	private void SetAllItemsChecked(bool check)
	{
		for (int i = 0; i < this.checkedListBox2.Items.Count; i++)
		{
			this.checkedListBox2.SetItemChecked(i, check);
		}		
	}
	private IEnumerable<string> ReadInstallerLines()
	{
		string installerfilename = path + "installer.ini";
		string installertext = File.ReadAllText(installerfilename);
		return File.ReadLines(path + "installer.ini");
	}
	
	private void SetAllProductsChecked(IList<string> installerLines, bool check)
	{
		for (var i = 0; i < installerLines.Count; i++)
		{
			if (installerLines[i].Contains("product="))
			{
				installerLines[i] = check 
					? installerLines[i].Replace("#product", "product") 
					: installerLines[i].Replace("product", "#product");
			}
		}
	}
	private void SaveInstaller(IEnumerable<string> installerLines)
	{
		string installerfilename = path + "installer.ini";
		File.WriteAllLines(installerfilename, installerLines);
	}
	
