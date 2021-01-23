    async Task DownLoadData ()
		{
			
			string url2 = "http://papajohn.pp.ua/?mkapi=getProductsByCat&cat_id=83";
        
			ProgressDialog progress = new ProgressDialog (this, Resource.Style.progress_bar_style);
			progress.Indeterminate = true;
			progress.SetProgressStyle (ProgressDialogStyle.Spinner);
			progress.SetCancelable (false);
			progress.SetContentView (Resource.Layout.ProgressLayout);
			var json2 = await FetchAsync2(url2);
        var path2 = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        var filename2 = System.IO.Path.Combine(path2, "cache2.txt");
        File.WriteAllText(filename2, json2);
      progress.Dismiss ();	
      }
