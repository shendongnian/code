      public class B{
            public Inputs Test { get; set; }
      }
      var b = new B();
      b.Test = new Inputs();
      b.Test.Something = txtSomething.Text;
***
      public class B{
            public B(Inputs myB)
            { this.MyB = myB; }
            public Inputs MyB { get; set; }
      }
    Inputs test = new Inputs();
    test.Something = txtSomething.Text;
     var b = new B(test );
