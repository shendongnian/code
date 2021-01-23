    public static void WriteUser(String path, String user, String auth, String pass, DateTime date)
    {
        try
        {
            File.WriteAllText(
                "mydata",
                $"{user}{{\nAuth:{auth}\nPass:{pass}\nDateCreated:{date}");
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message + "\n Cannot write to file.");
            return;
        }
        bw.Close();
    }
