    this.InitializeComponent();
    List<FlyoutData> data = new List<FlyoutData>();
    data.Add(new FlyoutData("Folder1"));
    data.Add(new FlyoutData("Folder2"));
    lstEmailFolder.ItemsSource = data;
___
     public class FlyoutData
    {
        public string Foldername { get; set; }
        public FlyoutData(string Foldername)
        {
            this.Foldername = Foldername;
          
        }
    }
  
