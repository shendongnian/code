     Regex _regex=new Regex(@"\[[\w :]+\] <SYSTEMWIDE_MESSAGE>: 
                           \w+ has been defeated by a group of hardy adventurers! Please join
                           us in congratulating \w+ along with everyone else who participated
                           in this achievement!")
     System.IO.StreamReader file = 
               new System.IO.StreamReader(@"YourLogFile.txt");
         while((line = file.ReadLine()) != null)
         {
             Match match=_regex.Match(line);
             if(match.Success)
             {
            
               //Match Found
              }
          }
       file.Close();
