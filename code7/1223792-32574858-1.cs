    public partial class ListOfIP : UserControl
    {
        public LinkCollection IPList { get; private set; }
        public ListOfIP()
        {
            DataContext = this;
            InitializeComponent();
            IPList = new LinkCollection();
            testMethod(IPList);
        }
    
        public void testMethod(LinkCollection IPList)
        {
            IPList.Add(new Link() { DisplayName = "IP1" });
            IPList.Add(new Link() { DisplayName = "IP2" });
            IPList.Add(new Link() { DisplayName = "IP3" });
        }
    }
