    public class ReadNewestEntries {
      public int entryId {get;set}
      public List<someDataType> ReadNewEntries() {
         // some code to read the database, using the entryId
         
         // Get last ID read
         entryId = dataList.Max(x => x.entryId);
      }
    }
    // in main class:
    ReadNewestEntries getNewEntries = new ReadNewestEntries();
    // Then just keep this class instance around to use
    List<someDataType> = getNewEntries.ReadNewEntries();
