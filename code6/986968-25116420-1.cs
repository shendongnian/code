    public ProfilePage()
        {
            InitializeComponent();
            listPicker.SetValue(Microsoft.Phone.Controls.ListPicker.ItemCountThresholdProperty, 3);
            List<BloodGroupDetail> source = new List<BloodGroupDetail>();
            source.Add(new BloodGroupDetail() { BloodGroupItems = "A+" });
            source.Add(new BloodGroupDetail() { BloodGroupItems = "B+" });
            source.Add(new BloodGroupDetail() { BloodGroupItems = "O+" });
            source.Add(new BloodGroupDetail() { BloodGroupItems = "AB+" });
            this.listPicker.ItemsSource = source;          
        }
        public class BloodGroupDetail
        {
            public string BloodGroupItems { get; set; }
        }
