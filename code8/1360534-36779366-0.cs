    public sealed partial class SPList : Page
    {
        private ObservableCollection<ThreeColumnList> threeColumnLists;
    
        public ObservableCollection<ThreeColumnList> ThreeColumnLists
        {
            get { return threeColumnLists ?? (threeColumnLists = new ObservableCollection<ThreeColumnList>()); }
            set { threeColumnLists = value; }
        }
        public SPList()
        {
            this.InitializeComponent();
            LoadData();
        }
    
        private async void LoadData()
        {
            //you can also change the private threeColumnLists to a static 
            // and do 
            //if(ThreeColumnLists.Count==0) 
            //   ThreeColumnLists = await ThreeColumnListManager.GetListAsync();
            ThreeColumnLists = await ThreeColumnListManager.GetListAsync();
            //can also do
            // await ThreeColumnListManager.readList(ThreeColumnLists);
        }
    }
