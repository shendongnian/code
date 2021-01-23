      string[] lines = System.IO.ReadAllLines(@"C:\readme.txt");
        string stringTobeDisplayed = string.Empty;
        foreach(string line in lines)
        {
            stringTobeDisplayed = string.Empty;
            string [] words = line.Split();
             //I assume that the first word in every line is the key word to be found
              if (word[0].Trim()=="pokhara")
                {
                    Console.WriteLine("Match Found");
                    
                    for(int i=1 ; i < words.Length ; i++)
                     {
                         stringTobeDisplayed += words[i]
                     }
                    
                     Console.WriteLine(stringTobeDisplayed);
                     
                }
            
        }
