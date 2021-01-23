    var errorWriter =  Task.Run(() => 
            
            {
                try
                {
                    string TargetFile = "F:\\file.txt";
                    using (StreamWriter sw = File.AppendText(TargetFile))
                    {
                        sw.WriteLine("LOG: an error occured\n");
                        sw.Close();
                        return "success";
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                  //  throw; _________________ don't throw here 
                }
            
            });
