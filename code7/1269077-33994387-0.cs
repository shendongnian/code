    public static void Read()
	{
		string pathImportFile = @"C:\Users\public\WaageLAU.txt";				
		string msgIn = "msgIn";
		
		// seperators
		string[] tum = new string[] {"tum"};
		string[] eit = new string[] {"eit"};
		string[] kel = new string[] {"kel"};
		string[] tto = new string[] {"tto"};
		string[] ara = new string[] {"ara"};
		string[] och = new string[] {"och"};
		string[] rig = new string[] {"rig"};
		StringBuilder dataImport = new StringBuilder();
		
		while (_continue)
		{	
			try
				{
					msgIn = _serialPort.ReadLine();	
				}
				catch (TimeoutException) { }
		
			if (msgIn.Contains("Datum"))
				{
					dataImport.Append(msgIn.Split(tum, StringSplitOptions.None) + "\t\t");				
				}
			else if (msgIn.Contains("Zeit"))
				{
					dataImport.Append(msgIn.Split(eit, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Artikel"))
				{
					dataImport.Append(msgIn.Split(kel, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Brutto"))
				{
					dataImport.Append(msgIn.Split(tto, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Tara"))
				{
					dataImport.Append(msgIn.Split(ara, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Netto"))
				{
					dataImport.Append(msgIn.Split(tto, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Hoch"))
				{
					dataImport.Append(msgIn.Split(och, StringSplitOptions.RemoveEmptyEntries) + "\t\t");
				}
			else if (msgIn.Contains("Niedrig"))
				{				
					dataImport.Append(msgIn.Split(rig,StringSplitOptions.RemoveEmptyEntries));
					
					try
						{ 
							using (System.IO.StreamWriter fileImport = new System.IO.StreamWriter(pathImportFile,true))
							{
								
								fileImport.WriteLine(string.Join("",dataImport));
								//fileImport.WriteLine(dataImport.ToString());							// schreibt die Zeile in die Textdatei	
							
							}		
						}catch (TimeoutException) { }
					dataImport.Clear();
				}
			else
			{
				// Fehlermeldung ausgeben/protokollieren
			}
		}
	}
