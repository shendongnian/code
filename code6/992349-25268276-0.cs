     int counter = 0;
            string line;
    
            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(@"c:\AnswerFile.txt");
    	System.IO.StreamWriter fileWriter = new System.IO.StreamWriter(@"C:\outputFile.txt");
    
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
    	        fileWriter.WriteLine(line);
                counter++;
            }
    
            file.Close();
    	    fileWriter.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.
            System.Console.ReadLine();
