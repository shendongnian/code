    foreach (FileInfo file in files)
    {
    	//reads the file contents
    	var content = File.ReadAllText(file.FullName);
    
    	if (textwords.Any(tw => Regex.IsMatch(content, @"\b" + tw.Trim() + @"\b", RegexOptions.IgnoreCase))
        {
    		try
    		{
    			File.Move(file.FullName, Path.Combine(@"F:\UNI\Year 2\Tri 2\Software Engineering Methods\Coursework\Noogle system\Quarantin_Messages", file.Name));
    		}
    		catch (IOException cannot_Move_File)
    		{
    			MessageBox.Show(cannot_Move_File.ToString());
    		}
    	}
    	else
    	{
    		//else it is moved To valid messages
    		try
    		{
    			File.Copy(file.FullName, @"F:\UNI\Year 2\Tri 2\Software Engineering Methods\Coursework\Noogle system\Valid_Messages\" + file.Name);
    		}
    		catch (IOException cannot_Move_File)
    		{
    			MessageBox.Show(cannot_Move_File.ToString());
    		}
    	}
    }
