    public void printHasFaerieCharm()
    {
        List<bool> charms = aFaerieCharm();
        for (int i = 0; i < charms.Count; ++i)
        {
            Console.WriteLine("Ally " + i + ": " + (charms[i] ? ".25" : "false"));
         }
    }
