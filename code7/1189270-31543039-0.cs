    while (readIt.Peek() >= 0)
    {
        var line = readIt.ReadLine();
    	if (line.Contains("LogObjectUsage@1000000000 : Record 50000;"))
    	{
    		MessageBox.Show("Fajl ne treba da se menja");
    		System.IO.File.Copy(txtb_Input_Folder.Text + Path.GetFileName(fileName), txtb_Output_folder.Text + Path.GetFileName(fileName), true);
    
    	}
    	else
    	{
    		if (line.Contains("PROPERTIES") && !line.Contains("OBJECT-PROPERTIES")) {
    			sb.Append(line);
    			nasao_prop = true;
    		}
    		.........
    	}
    	...
    }
