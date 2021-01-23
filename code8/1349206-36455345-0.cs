    class X
    {
      public string x;
    }
    
    class Y : X
    {
      public string y;
    }
    
    class A
    {
      string a;
      protected void setX(X x)
      {
        x.x = a;
      }
      public virtual X createX()
      {
        var x = new X();
        setX(x);
        return x;
      }
    }
    
    class B : A
    {
      string b;
      protected void setY(Y y)
      {
        base.setX(y);
        y.y = b;
      }
      public override X createX()
      {
        var y = new Y();
        setY(y);
        return y;
      }
    }
    
    ...
    var c = new B();
    var z = c.createX();
