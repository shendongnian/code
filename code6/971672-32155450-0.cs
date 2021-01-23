    public sealed partial class ShareText : SDKTemplate.Common.SharePage
    {
        public ShareText()
        {
            this.InitializeComponent();
            LoadList();
        }
        List<Windows.Storage.IStorageItem> list { get; set; }
        public async void LoadList()
        {
            var uri = new Uri("ms-appx:///test.txt");
            var item = await StorageFile.GetFileFromApplicationUriAsync(uri);
            list = new List<IStorageItem>();
            list.Add(item);
        }
        protected override bool GetShareContent(DataRequest request)
        {
            bool succeeded = false;
            string dataPackageText = TextToShare.Text;
            if (!String.IsNullOrEmpty(dataPackageText))
            {
                DataPackage requestData = request.Data;
                requestData.Properties.Title = TitleInputBox.Text;
                requestData.Properties.Description = DescriptionInputBox.Text; // The description is optional.
                requestData.Properties.ContentSourceApplicationLink = ApplicationLink;
                requestData.SetText(dataPackageText);
                requestData.SetStorageItems(list);
                succeeded = true;
            }
            else
            {
                request.FailWithDisplayText("Enter the text you would like to share and try again.");
            }
            return succeeded;
        }
        
    }
