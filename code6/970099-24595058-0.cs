    public struct MyClass
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
    var items = new Dictionary<MyClass, Bool>();
    items[ new MyClass{ X = 3, Y = 7 } ] = false;
    items[ new MyClass{ X = -12, Y = -24 } ] = true;
    Assert.IsFalse( items[ new MyClass{ X = 3, Y = 7 } ] );
    Assert.IsTrue( items[ new MyClass{ X = -12, Y = -24 } ] );
    items[ new MyClass{ X = 3, Y = 7 } ] = true;
    Assert.IsTrue( items[ new MyClass{ X = 3, Y = 7 } ] );
