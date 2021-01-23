    Process myProcess = new Process();
    
                try
                {
                    // true is the default, but it is important not to set it to false
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = "http://some.domain.tld/bla";
                    myProcess.Start();
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }
            }
