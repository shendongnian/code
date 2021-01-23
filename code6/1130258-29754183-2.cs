     public static void FileOutput(string path, bool rewrite, List<int> NumberOfWords)
    {
        StreamWriter OutPath;
        try
        {
            OutPath = new StreamWriter(path, rewrite);
            for(int i = 0; i < NumberOfWords; i++)
            {
                try
                {
                    OutPath.Write(NumberOfWords[i]);
                }
                catch(IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        OutPath.Close();
        }
        catch(IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
