    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        //GC.Collect();
        BukuAudio dlList = e.Parameter as BukuAudio;
        if (dlList != null)
        {
            //DownloadBuku(dlList.BundlePath);
            //downloadfilename.Text = dlList.BundleName;
            //Uri uri = new Uri(dlList.BundlePath);
            //string filename = System.IO.Path.GetFileNameWithoutExtension(uri.LocalPath);
            //downloadfilename.Text = String.Format("Unduh '{0}'", filename);
            foreach (var path in dlList.BundlePath)
            {
                DownloadBuku(path);
                int i = 0;
                downloadfilename.Text = dlList.BundleName.ElementAt(i);
                i++;
                Uri uri = new Uri(path);
                string filename = System.IO.Path.GetFileNameWithoutExtension(uri.LocalPath);
                downloadfilename.Text = String.Format("Unduh '{0}'", filename);
            }
            DownloadProgress.Visibility = Visibility.Visible;
            downloadfilename.Visibility = Visibility.Visible;
            statusdownload.Visibility = Visibility.Visible;
        }
        else
        {
            DownloadProgress.Visibility = Visibility.Collapsed;
            downloadfilename.Visibility = Visibility.Collapsed;
            statusdownload.Visibility = Visibility.Collapsed;
        }
    }
