    public class Pipe
    {
      // whole bunch of private member variables such as bandwidth, latency, download limit 
      // etc,
    
      public int GetCost()
      {
         // work out cost based on above
      }
      public static Pipe MakeBigFatPipe()
      {
          var result = new Pipe();
          // sets up the member variables one way
          return result;
      }
      public static Pipe MakeCheapestPossiblePipe()
      {
          var result = new Pipe();
          // sets up the member variables another way
          return result;
      }
    }
