     public class MainViewModel
    {
        public AnotherViewModel avm { get; set; }
        public int ImportantInfo { get; set; }
        public MainViewModel()
        {
            avm = new AnotherViewModel(this);
        }
    }
    public class AnotherViewModel
    {
        public MainViewModel mvm { get; set; }
        public AnotherViewModel(MainViewModel mvm)
        {
            this.mvm = mvm;
            MoreImportantINfo = this.mvm.ImportantInfo;
        }
        public int MoreImportantINfo { get; set; }      
    }
