    public static void Info(string text)
    {
        text = string.Format("[{0:d/M/yyyy HH:mm:ss}] {1}", DateTime.Now, text);
        plainWrite(text); 
    }
