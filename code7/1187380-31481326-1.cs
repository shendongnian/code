    string pdf = "__602256510000; 602256510002; 602256500001; TRACKING ";
    Regex RxTrack = new Regex(@"(?:(?<TrackingNumber>[a-zA-Z0-9]+);\s)+TRACKING");
    
    Match trackMatch = RxTrack.Match( pdf );
    if ( trackMatch.Success )
    {
        CaptureCollection cc = trackMatch.Groups["TrackingNumber"].Captures;
        for (int i = 0; i < cc.Count; i++)
            Console.WriteLine("[{0}] = {1}", i, cc[i].Value);
    }
