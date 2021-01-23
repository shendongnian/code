    stopwatch.Restart();
    Parallel.For(0, 1000, i =>
    {
       foreach (var elm in xdoc.Descendants("def"))
       {
            if (elm.Attribute("name").Value == "def")
            {
                   xelm = elm;
                   break;
             }
        }
    });
    stopwatch.Stop();
    Console.WriteLine(stopwatch.ElapsedMilliseconds);
