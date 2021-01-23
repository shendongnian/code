    public static string ReadFile()
        {
            var stringFile = "";
            StreamReader streamReader = null;
            try
            {
                try
                {
                    streamReader = new StreamReader(@"C:\Users\Chiranjib\Downloads\C# Sample Input Files\InputParam.txt"); //Usage of the Verbatim Literal
                    stringFile = streamReader.ReadToEnd();
                    return stringFile
                }
                catch (FileNotFoundException exfl)
                {
                    string filepath = @"C:\Users\Chiranjib\Downloads\C# Sample Input Files\LogFiles.txt";
                    if (File.Exists(filepath))
                    {
                        StreamWriter sw = new StreamWriter(filepath);
                        sw.WriteLine("Item you are searching for {0} just threw an {1} error ", exfl.FileName, exfl.GetType().Name);
                        Console.WriteLine("Application stopped unexpectedly");
                    }
                    else
                    {
                        throw new FileNotFoundException("Log File not found", exfl);
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    return string.Empty;
                }
                //Code inside finally gets executed even if the catch block returns when an exception happens 
                finally
                {
                    //Resource de-allocation happens here
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                    Console.WriteLine("Finally block executed");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Log file not found ");
                Console.WriteLine("Original exception " + ex.GetType().Name);
                Console.WriteLine("Inner Exception " + ex.InnerException.GetType().Name);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
                Console.WriteLine("Finally block executed");
            }
            return stringFile;
        }
