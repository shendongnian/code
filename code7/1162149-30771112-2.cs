    private TestScheduler sched {get; set;}
    public IObservable<AccelerometerFrame_raw> DataStream { get; protected set; }
    ctor()
    {
       DataStream = SetupDeviceStream();
    }
      private IObservable<AccelerometerFrame_raw> SetupDeviceStream()
      {
         var framesArray = 
           new Recorded<Notification<AccelerometerFrame_raw>>[allFrames.Count+1];
         int i = 0;
         long timeStamp = 0;
         foreach(var item in allFrames)
         {
            timeStamp += (long) (item.TimeStampSeconds * 1000.0);
            framesArray[i] = new Recorded<Notification<AccelerometerFrame_raw>>(
               timeStamp, 
               Notification.CreateOnNext(item));
            i++;
         }
         framesArray[i] = new Recorded<Notification<AccelerometerFrame_raw>>(
               timeStamp + 10, 
               Notification.CreateOnCompleted<AccelerometerFrame_raw>());
         sched = new TestScheduler();
         var stream =sched.CreateColdObservable(framesArray);
         return stream;
      }
