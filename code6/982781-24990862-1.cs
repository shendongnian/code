    Reachability reachabilityObj = Reachability.InternetConnectionStatus ();
    if (reachabilityObj == NetworkStatus.NotReachable) {
        Console.WriteLine ("Not connect to Internet");
    } else {
        Console.WriteLine ("connect to Internet");
    }
