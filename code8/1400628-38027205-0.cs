    class C {
     public static C Instance; 
     public C() {
      Instance = this; //publish/leak
      throw ...;
     }
    }
