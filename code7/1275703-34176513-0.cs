    string[] lines = File.ReadAllLines(Authentication.AuthenticationFileName);
    for (int i = 0; i < lines.Length; i++)
    {
      string val = lines[i].Split('=')[1].Trim();
    }
