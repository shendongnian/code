    while ((line = Sr.ReadLine()) != null)
    {
        if (line.Length >= 12 && line.Substring(0, 12) == "HelloMessage")
        {
            string[] StrMsg = line.Split('=');
            HelloMsg = StrMsg[1].Trim();
        }
    }
