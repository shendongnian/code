    class Demo {
      public string name;
    }
    
    var a = new Demo();
    a.name = 'John';
    var b = new Demo();
    b.name = 'Bob';
    // At this point, a.name is still John. a and b each have their own name.
