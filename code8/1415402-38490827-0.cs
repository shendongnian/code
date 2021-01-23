    public class Test {
      private int _propA;
      private int _propB;
      public int PropA {get { return _propA; }}
      public int PropB {get { return _propB; }}
    } 
 
    public class TestSwapped {
      private int _propA;
      private int _propB;
      // please, notice swapped backing fields
      public int PropA {get { return _propB; }}
      public int PropB {get { return _propA; }}
    } 
   
