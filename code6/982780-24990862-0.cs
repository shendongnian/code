    Reachability reachabilityObj = Reachability.InternetConnectionStatus ();
    if (reachabilityObj == NotReachable) {
        Console.WriteLine ("Not connect to Internet");
    } else {
        Console.WriteLine ("connect to Internet");
    }
