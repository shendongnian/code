    static async Task<string> ReadTextAsync() 
            {
                string textContents;
                Task<string> readFromText;
    
                using (StreamReader reader =  File.OpenText("email.txt"))
                {
                    readFromText = await Task.Run(() => reader != null ? reader.ReadToEndAsync() : null);
                    textContents = readFromText;
    
                }
    
                return textContents;     
            }
    
            static Task test ()
            {
                string capture = ReadTextAsync();
                Console.WriteLine(capture);
            }               
