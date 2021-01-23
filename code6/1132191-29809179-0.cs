		using (var stream = File.Open(filePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        using (XmlReader reader = XmlReader.Create(stream))
        {
            while (reader.Read())
            {
               	// Only detect start elements.
                if (!reader.IsStartElement())
                {
			    	continue;
				}
				
				if (reader.Name != "Component")
				{
					continue;
				}
				
				fileElements.ComponentName  = reader["Name"];
				fileElements.DateRun 		= reader["DateRun"];
				fileElements.Passed 		= reader["Passed"];
           }
           if (filePath.ToLower().Contains("ebsserver"))
           {
               UpdateDataTable1(fileElements);
           }
           else if (filePath.ToLower().Contains("ebsui"))
           {
               UpdateDataTable2(fileElements);
           }
           else
           {
               UpdateDataTable3(fileElements);
           }
       }
