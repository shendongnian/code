        counter = 0;
        string line;
        bool validCheck = true;
        // Read the file and display it line by line.
		using( StreamReader reader = File.OpenText(deckFile) )
		{
			while(!reader.EndOfStream && validCheck == true)
			{
				string line = reader.ReadLine();
				if (line.Split(',')[1] == Form1.tempUsernameOut)
				{
                    validCheck = false;
				}
				
				counter++; //Already holds number of lines
			}
		}
		
		if(validCheck)
		{
			using( StreamWriter writer = File.AppendText(deckFile) )
			{
				string deckWriting = string.Format("{0},{1},1,,,,,,,,,,,2,,,,,,,,,,,3,,,,,,,,,,,4,,,,,,,,,,,5,,,,,,,,,,,", counter, Form1.tempUsernameOut);
				writer.WriteLine(deckWriting);
			}
		}
