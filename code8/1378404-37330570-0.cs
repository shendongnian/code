     public softDrinkProductDet()
        {
            this.InitializeComponent();
            DataTransferManager dfm = DataTransferManager.GetForCurrentView();
            dfm.DataRequested += dfm_DataRequested;
        }
        void dfm_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            DataRequest dr = args.Request;
            dr.Data.Properties.Title = "Your Title";
            dr.Data.Properties.Description = "Description";
            dr.Data.SetText("Some Shareing");
        } 
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataTransferManager.ShowShareUI();
        }
