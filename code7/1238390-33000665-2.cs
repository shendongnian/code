    public class FileCompareUIFactory{
      private static FileCompareUIFactory _instance = null;
      public FileCompareUIFactory Instance{
        get{ return (_instance = _instance ?? new FileCompareUIFactory()); }
      }
      protected FileCompareUIFactory(){ }
    }
