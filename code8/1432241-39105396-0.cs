    public class Program
    {
       unsafe
       {
          var zeroten = new Zeroton();
          Monitor.Enter(zeroten);
          ~this(); // this calls teh destructor
          Environment.Exit();
       }
    }
