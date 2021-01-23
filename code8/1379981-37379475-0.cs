       try 
        {
           // this will get all the files in directory C:\MyFolder\ 
            string[] files = Directory.GetFiles(@"C:\MyFolder\", "*");
           // Iterate over all file names to check if it consists only numbers
            foreach (string file in files) 
            {
                bool isFileNameNumericOnly = true;
              // check if file name contains only numbers 
               // if yes then store the name of the file. 
                 
                 foreach (char c in file)
                  {
                    // This condition checks if a char is a digit or not
                     if (c < '0' || c > '9')
                      {
                        isFileNameNumericOnly = false;
                        break;
                      }
                  }
                  if(isFileNameNumericOnly == true)
                  {
                     //here you can save the name of file
                  }
             }
            
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
