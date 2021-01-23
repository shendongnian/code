    var waitUntil = System.DateTime.Now.AddSeconds(1);
    while (System.DateTime.Now < waitUntil)
    {
        Application.DoEvents();
    }
