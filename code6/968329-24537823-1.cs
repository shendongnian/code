    var waitUntil = System.DateTime.AddSeconds(1);
    while (System.DateTime.Now < waitUntil)
    {
        Application.DoEvents();
    }
