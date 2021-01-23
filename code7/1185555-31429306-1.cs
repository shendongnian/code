      using System.Reflection;
      ...
      public class Receive {
        // using public fields is a bad practice
        // let "Head" be a property 
        public int Head {
          get;
          set;
        }
        // Bad practice
        public int UglyHead = 5;
    
        public Receive() {
          Head = 10;
        }
      }
    
      ...
    
      string bodyname = "Head";
    
      Receive bodyPart = new Receive();
      // Property reading 
      int v = (int) (bodyPart.GetType().GetProperty(bodyname).GetValue(bodyPart));
      // Field reading
      int v2 = (int) (bodyPart.GetType().GetField("UglyHead").GetValue(bodyPart));
