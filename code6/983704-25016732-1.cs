    public static void Play(string fileName)
    {
        if (File.Exists(fileName))
        {
            Program.Player.SoundLocation = "";
            Program.Player.SoundLocation = fileName;
            Program.Player.Load();
            if (Program.Player.IsLoadCompleted)
            {
                Program.Player.Play();
            }
        }
    }
