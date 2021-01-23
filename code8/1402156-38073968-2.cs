    StringBuilder sb = new StringBuilder();
        string headerLine = string.Empty;
        int currentLine = 0;
            using (StreamReader sr = new StreamReader(@"C:\Users\p2\Desktop\variablen.txt"))
           {
                           string line;
                           
                           // Read and display lines from the file until 
                           // the end of the file is reached. 
                           while ((line = sr.ReadLine()) != null)
                           {
                              currentLine++; //increment to keep track of current line number.
                              if(currentLine == 1)
                              {
                                headerLine = line;
                                continue; //skips rest of the processing and goes to next line in while loop
                              }
                              sb.Append((line);
                              
                           }
            }
            header.Text = headerLine;
            monate2.Text = sb.ToString();
