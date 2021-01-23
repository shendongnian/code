    string searchString = @"19:09:41 PM : [ 0] 0.0-100.2 sec 796 MBytes 66.6 Mbits/sec 0.273 ms 2454161/3029570 (81%)";
    Regex regex = new Regex( @"(?<TP>\d+(\.\d+)?)\s+Mbits/sec", RegexOptions.ExplicitCapture );
    Match match = regex.Match( searchString );
    if ( match.Success )
    {
        // If you only need the string representation of the value,
        // do this and you're done:
        string bitrateString = match.Groups["TP"].Value;
        // If you want to parse the string into an actual floating-point type,
        // do this:
        double bitrate;
        bitrate = double.Parse( match.Groups["TP"].Value );
        Console.Out.WriteLine( bitrate );
    }
    else
    {
        Console.Out.WriteLine( "Could not match." );
    }
