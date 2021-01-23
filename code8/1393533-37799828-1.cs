    public DoAsyncWork(callback) // called asynchronously
    {
      Stopwatch watch = Stopwatch.Startnew();
      // do work
      var time = watch.ElapsedMilliseconds / 1000.0;
      callback(null, new { time: time });
    }
