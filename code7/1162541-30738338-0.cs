    // APIObject provided to you
    public class APIObject {
      private string foo;
      public void setFoo(string _foo) {
        this.foo = _foo;
      }
    }
    // Global Timestamp, readonly version for wrappers and readwrite version for sync
    public class GlobalTimestamp {
      protected long timestamp = long.MaxValue;
      public long getTimestamp() {
        return timestamp;
      }
    }
    public class GlobalTimestampRW extends GlobalTimestamp {
      public void startSync(long _timestamp) {
        long value = System.Threading.Interlocked.CompareExchange(ref timestamp, _timestamp, long.MaxValue);
        if(value != long.MaxValue) throw exception; // somebody else called this method already
      }
      public void endSync(long _timestamp) {
        long value = System.Threading.Interlocked.CompareExchange(ref timestamp, long.MaxValue, _timestamp);
        if(value != _timestamp) throw exception; // somebody else called this method already
      }
    }
    // Wrapper
    public class APIWrapper {
      private APIObject apiObject;
      private GlobalTimestamp globalTimestamp;
      private long localTimestamp = long.MinValue;
      public APIObject setFoo(string _foo) {
        long tempGlobalTimestamp = globalTimestamp.getTimestamp();
        if(tempGlobalTimestamp == long.MaxValue || tempGlobalTimestamp == localTimestamp) {
          apiObject.setFoo(_foo);
          return apiObject;
        } else {
          apiObject = apiObject.copy();
          apiObject.setFoo(_foo);
          localTimestamp = tempGlobalTimestamp;
          return apiObject;
        }
      }
    }
    GlobalTimestampRW globalTimestamp;
    new Task(() =>
    {
        while(true)
        {
          long timestamp = DateTime.UtcNow.ToBinary();
          globalTimestamp.startSync(timestamp);
          API.CriticalOperationStart(); // Between start and end no API Object may be used
          API.CriticalOperationEnd();
          globalTimestamp.endSync(timestamp);
        }
    }, TaskCreationOptions.LongRunning).Start();
