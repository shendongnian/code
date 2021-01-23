    enum SameName { Value }
    class Tester
    {
       void Method1() {
          SameName SameName;
          SameName test = SameName.Value; // Works!
       }
       void Method2() {
          string SameName;
          SameName test = SameName.Value; // Doesn't work! Expects string method Value
       }
    }
