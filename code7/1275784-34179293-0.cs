    ...
    using (var sr = new StreamReader(@"c:\HRSystem\SOAPResult\Info.csv"))
    {
        sr.ReadLine(); // if you have a header in the file
        while (!sr.EndOfStream)
        {
            var columns = sr.ReadLine().Split(',');
            // process columns as per needed.
        }
    }
