      int counter = 1;
            string line;
            
            // Read the file and display it line by line.
            System.IO.StreamReader file = 
               new System.IO.StreamReader("C:\\Users\\Donavon\\Desktop\\old.sql");
            
            while((line = file.ReadLine()) != null)
            {
               line.Replace("('',", "('" + counter.ToString() + "',");;
               counter++;
            }
