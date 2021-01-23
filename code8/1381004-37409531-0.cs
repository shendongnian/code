    string[] lines = File.ReadAllLines(@"d:\test.txt");//replace your directory. We're getting all lines from a text file.
			
			string inputToSearchFor = "\"FastModeIdleImmediateCount\"=dword:00000000";	//that's the string to search for
			
			int indexOfMatchingLine = Array.FindIndex(lines, line => line == inputToSearchFor);	//getting the index of the line, which equals the matchcode
			
			string nearestHotKey = String.Empty;
			for(int i = indexOfMatchingLine; i >=0; i--)	//looping for lines above the matched one to find the hotkey
			{				
				if(lines[i].IndexOf("[HKEY_") == 0)			//if we find a line which begins with "[HKEY_" (that means it's a hotkey, right?)
				{
					nearestHotKey = lines[i];				//we get the line into our hotkey string
					break;									//breaking the loop
				}
			}
			
			if(nearestHotKey != String.Empty)				//we have actually found a hotkey, so our string is not empty
			{
				//add code...
			}
