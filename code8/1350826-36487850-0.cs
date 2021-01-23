    public partial class CustomControl : UserControl
    {
        public string txt_Field1 { get; set; }
        public string txt_Field2 { get; set; }
        public string rad_RadBtn1 { get; set; }
        public string rad_RadBtn2 { get; set; }
        public string rad_RadBtn3 { get; set; }
        public string rad_RadBtn4 { get; set; }
        public string[] listContents { get; set; }
        public CustomControl()
        {
            InitializeComponent();
            listContents = new string[5] { "Slot 1", "Slot 2", "Slot 3", "Slot 4", "Slot 5" };
            DataContext = this;
        }
    }
