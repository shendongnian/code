    class TEST {
      private string test = "test"; // this is a member of the class
      private void testVariable(){
        string test = "somethingOther"; // this is a local variable that shadows the class member
        Console.WriteLine(test); // this will use the local variable, it can't see the class member
      }
    }
