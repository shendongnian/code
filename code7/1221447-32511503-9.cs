    class BaseDemo {
      abstract void xyz() {
        System.Console.WriteLine("in Basedemo.xyz");
      }
    }
    
    class SpecificDemo1: BaseDemo {
      override void xyz() {
        System.Console.WriteLine("in SpecificDemo1.xyz");
      }
    }
    
    class SpecificDemo2: BaseDemo {
      override void xyz() {
        System.Console.WriteLine("in SpecificDemo2.xyz");
      }
    }
