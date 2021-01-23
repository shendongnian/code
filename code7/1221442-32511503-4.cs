    class Demo {
      public string name;
      public void WhoAmI() {
        System.Console.WriteLine(this.name);
      }
    }
    
    var a = new Demo();
    a.name = 'John';
    var b = new Demo();
    b.name = 'Bob';
    a.WhoAmI(); // outputs 'John'
