    public class Essentials
    {
      public virtual void DoSomething()
      {
        //Do stuff with field 1
      }
    }
    public class NetworkEssentials : Essentials
    {
      public override void DoSomething()
      {
        base.DoSomething(); // handle field 1
        // Code to handle other fields either here, before the call to base.DoSomething(), or both.
      }
    }
