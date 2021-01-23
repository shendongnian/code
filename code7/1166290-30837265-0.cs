     string line = fileObject.ReadLine();
     int constant = 60; //For your example
     int num = 0;
     string []tokens = line.Split(); //No arguments in this method means space is used as the delimeter
     foreach(string s in tokens)
     {
         if(Int32.TryParse(s, out num)
         {
             if(num > constant)
             {
                 //Logic to append to Rich Text Box
             }
         }
     }
