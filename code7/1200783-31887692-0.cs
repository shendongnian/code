    public void DoStuff()
    {
        for(int i = 0; i < 20; i++)
        {
            WriteStuff("blah" + i);
        }
    }
    
    private bool WriteStuff(string text)
    {
        using (StreamWriter writer = new StreamWriter("C:\\log.txt", false))
        {
            writer.Write("blah");
        }
    }
