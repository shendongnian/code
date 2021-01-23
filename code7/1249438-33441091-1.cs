    [RegisterAction]
    public class MyFirstPlugin: BasePlugin<bool>
    {
        protected override bool execute(ISerializable info = null)
        {
            try
            {
               // do stuff
               return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    [RegisterAction("MyFirstPlugin")]
    public class MySecondPlugin: BasePlugin<string>
    {
        protected override string execute(ISerializable info = null)
        {
            try
            {
               // do stuff
               return "success";
            }
            catch (Exception)
            {
                return "failed";
            }
        }
    }
