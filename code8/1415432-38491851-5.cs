    public class AwesomeObjectNameUpdater : Updater<AwesomeObject>
    {
          public AwesomeObjectNameUpdater(ILogger logger) :base("Awesome Name Updater", logger)
          {
          
          }
          protected override UpdateImpl(AwesomeObject updating)
          {
               //here your mission critical business logic will go
               updating.Name = "Mr.Fancy-Pants " + updating.Name;
          }
    }
