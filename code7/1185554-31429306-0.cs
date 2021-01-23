      using System.Reflection;
      ...
      public class Receive {
        // using public fields is a bad practice
        // let "Head" be a property 
        public int Head {
          get;
          set;
        }
    
        public Receive() {
          Head = 10;
        }
      }
    
      ...
    
      string bodyname = "Head";
    
      Receive bodyPart = new Receive();
    
      int v = (int) (bodyPart.GetType().GetProperty(bodyname).GetValue(bodyPart));
