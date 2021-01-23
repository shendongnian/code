    protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
            // After doing initial Setups
            LoadData();
         }
    // This method downloads Json asynchronously without blocking UI and without showing a Pre-loader.
    async Task LoadData()
		{
            var newRequestsResponse =await ServiceLayer.HttpGetForJson (newRequestsUrl);
          // Use the data here or show proper error message
        }
     // This method downloads Json asynchronously without blocking UI and shows a Pre-loader while downloading.
    async Task LoadData()
		{
            ProgressDialog progress = new ProgressDialog (this,Resource.Style.progress_bar_style);
			progress.Indeterminate = true;
			progress.SetProgressStyle (ProgressDialogStyle.Spinner);
			progress.SetCancelable (false);
			progress.Show ();
            var newRequestsResponse =await ServiceLayer.HttpGetForJson (newRequestsUrl);
            progress.Dismiss ();
          // Use the data here or show proper error message
        }
