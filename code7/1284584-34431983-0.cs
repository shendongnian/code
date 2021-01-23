      // 120 was a magic number, now it's a parameter
      // do you really want to pass attempts each time you call the method? No
      public static Double PingAverageTime(String host, int attempts = 3, int timeout = 120) {
        // Validate the input
        if (String.IsNullOrEmpty(host))
          throw new ArgumentNullError("host");
        else if (attempts <= 0)
          throw new ArgumentOutOfRangeError("attempts");
        else if (timeout < 0)
          throw new ArgumentOutOfRangeError("timeout");
    
        Double totalTime = 0; // Double: we don't want integer divison problems
    
        using (Ping ping = new Ping()) { // IDisposable - into using!
          PingReply replay = ping.Send(host, timeout);
    
          if (replay.Status == IPStatus.Success)
            totalTime += replay.RoundtripTime;
          else // not succeeded: so the time is infinite
            return Double.PositiveInfinity; // no connection - average time is infinite
        }
    
        return totalTime / attempts;
      }
