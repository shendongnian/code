    public class FileOpenerUtil
    {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fullFilePath"></param>
    /// <returns></returns>
    public static string ReadFileToString(string fullFilePath)
    {
        while (true)
        {
            try
            {
                //Method 1
                using (StreamReader sr = File.OpenText(fullFilePath))
                    {
                        string s;
                        StringBuilder message = new StringBuilder();
                        while ((s = sr.ReadLine()) != null)
                        {
                            message.Append(s).Append("\n");
                        }
                        return RemoveCarriageReturn(message.ToString());
                    }
                //Method 2
                /*
                    string[] lines = File.ReadAllLines(fullFilePath);
                    string fullMessage = lines.Aggregate("", (current, s) =>                                        current + s + "\n");
                    return RemoveCarriageReturn(fullMessage);*/
                }
                //Method 3
                /*
                    string s = File.ReadAllText(fullFilePath);
                    return RemoveCarriageReturn(s);*/
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Output file {0} not yet ready ({1})", fullFilePath, ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("Output file {0} not yet ready ({1})", fullFilePath, ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Output file {0} not yet ready ({1})", fullFilePath, ex.Message);
            }
        }
    }
    /// <summary>
    /// Verwijdert '\r' in een string sequence
    /// </summary>
    /// <param name="message">The text that has to be changed</param>
    /// <returns>The changed text</returns>
    private static string RemoveCarriageReturn(string message)
    {
        return message.Replace("\r", "");
    }
}
