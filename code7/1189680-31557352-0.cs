    private void PutTextIntoArray()
            {
                var array = ReadTextFile("C:\\WordList.txt").GetTotalWords();
            }    
    private static string ReadTextFile(string file)
            {
                try
                {
                    return File.ReadAllText(file);
                }
                catch (IOException ex)
                {
                    return ex.Message;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
    public static class Extensions
    {
            public static string ReplaceMultipleSpacesWith(this string text, string newString)
            {
                return Regex.Replace(text, @"\s+", newString);
            }
            public static string[] GetTotalWords(this string text)
            {
                text = text.Trim().ReplaceMultipleSpacesWith(" ");
                var words = text.Split(' ');
                return words;
            }
    }
