                int matches = 0;
                string lastID = words3[7].Substring(0, 8);
                for (int j = 7;  j < words2.Count(); j++)
                { 
                     string  results  = null;
                    //"results" is the current employee information line  
                    results = words3[j];
                    //The ID number of that employee 
                     string id = results.Substring(0, 8);
                    //Find and get all of the lines that start with employee ID from string[] words3
                    if ( !words3[j].Contains(lastID))
                     { 
                      
                        //j-matches are the indexes that match
                         for (int x = j - matches; x < j; x++)
                         {
                             Console.WriteLine(words3[j]);
                         }
                        //Found all of the matches so reset for new upcoming IDs
                         matches = 0;
                     }
                    else
                    {
                        matches++;
                    }  
                    if (lastID != id)
                     {
                         lastID = id;
                     }
                }
