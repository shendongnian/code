    public static void Info(string text)
    {
        text = "[" + string.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now) + "] " + text;
        plainWrite(text); 
    }
