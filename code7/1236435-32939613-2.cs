    Random rnd = new Random();
    int website = rnd.Next(0, numOfWebsites);
    switch(website)
    {
        case 1:
        {
            Process.Start("http://google.com");
        }
        case 2:
        {
            Process.Start("http://yahoo.com");
        }
    }
