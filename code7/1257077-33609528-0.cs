    public abstract class Command {
      protected Command(): this(null) {
      }
      protected Command(String details) {
        Details = details;
      }
      // I'd rather convert it into property
      public String Details {
        get;
        set; // may be "private set" will be better here
      }  
      public override string ToString() {
        return Details;
      }
      // TODO: think on delete or redesign this method:
      // Redundant: Details provide all the functional required
      // Bad name: "FromString" usually means create/return
      // instance by given details
      //  public static Command FromString(string details)  
      public virtual void FromString(String details) {
        Details = details;
      }
    }
    ...
    public class NetCommand: Command {
      public NetCommand(string details) : base(details) {
      }
    }
