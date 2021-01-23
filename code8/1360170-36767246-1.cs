      public bool PopulateList()
        {
            var success = true;
            var path = "Assets/Scripts/Editor/Extensions.txt";
            if (File.Exists(path))
               {
                  try
                      {
                         var fileContent = File.ReadAllLines(path);
                         foreach (var line in fileContent)
                            {
                            // Define what lines do you need and get needed extensions 
                            }
                      }
                  catch (Exception ex)
                      {
                        Log(ex); // it`s better to know the reason at least
                        success = false;
                      }
               }
         
           return succes;
         }
