     //Check for originals not introduced in web.
            if(original.Count > web.Count)
            {
        
               for(int y = web.Count; y < original.Count; y++)
        
               {
                  differences.Add(original[y][0]);
               }
            }
     //Check if Web has value, if not, everything else is done on the first for loop
             if(web.Count > 0)
             {
                 for(int i = 0; i < original.Count; i++)
                    {
                       if(!original[i][0].Equals(web[i][0]))
                          differences.Add(original[i][0]);
                    }
             }
               
