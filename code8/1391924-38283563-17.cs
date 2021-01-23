    using(var sw= new StreamWriter("c:\\temp\\test1.txt"))
    {
        for(int line=0; line<5000; line++)
        {
            sw.WriteLine(Guid.NewGuid().ToString());
        }
    }
