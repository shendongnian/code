    private void continueButton_Click(object sender, RoutedEventArgs e)
    { 
    	if(!File.Exists("NameData.xml"))
    	{
    		SaveFileInfo("NameData.xml");
    	} 
    	else if (!File.Exists("NameData2.xml"))
    	{
    		SaveFileInfo("NameData2.xml");
    	}
    	else if (!File.Exists("NameData3.xml"))
    	{
    		SaveFileInfo("NameData3.xml");
    	}
    	else
    	{
    		MessageBox.Show("You have passed the limit of existing characters" +
    			"To continue please return to the main menu and delete at least 1 character");
    	}
    }
    
    public SaveFileInfo(string fileName)
    {
    	try
    	{
    		NameSavingInformation nameInfo = new NameSavingInformation();
    		nameInfo.GeneratedName = generatedNameTexbox.Text;
    		SaveXml.SaveData(nameInfo, fileName);
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	} 
    }
