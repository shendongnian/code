    try
            {
                string lastline = "Your file name here"; // assuming you know the file your searching for
                foreach (string filePaths in Directory.GetDirectories(@"E:\Program Files (x86)\foobar2000\library\"))
                {
                    foreach (string f in Directory.GetFiles(filePaths, lastline))
                    {
                        Console.WriteLine(filePaths + lastline); // would print the filepath n the file name
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
