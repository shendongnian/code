     // Methods grouped by interface
     public interface IMasterModule
     {
         uint32 GetSerialNr();
     }
     public interface IEprom
     {
         string ReadDescriptor();
     }
     // Now for your huge class
     public class DSP : IMasterModule, IEprom
     {
         // Properties which expose the groups
         public IMasterModule MasterModule { get { return this; } }
         public IEprom        Eprom        { get { return this; } }
         // --------------- IMasterModule -------------
         // Now your methods, which have access to the main class
         public uint32 GetSerialNr()
         {
             ...
         }
         // ----------------- IEprom -----------------
         public string ReadDescriptor()
         {
            ...
         }
     }
