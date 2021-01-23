    DownloadHandler downer = new DownloadHandler(this);
    browser.DownloadHandler = downer;
    downer.OnBeforeDownloadFired += OnBeforeDownloadFired;
    downer.OnDownloadUpdatedFired += OnDownloadUpdatedFired;
         		
    private void OnBeforeDownloadFired(object sender, DownloadItem e)
    {
        this.UpdateDownloadAction("OnBeforeDownload", e);
    }
		
    private void OnDownloadUpdatedFired(object sender, DownloadItem e)
	{
		this.UpdateDownloadAction("OnDownloadUpdated", e);
    }
    
    private void UpdateDownloadAction(string downloadAction, DownloadItem downloadItem)
    {
        /*
        this.Dispatcher.Invoke(() =>
        {
            var viewModel = (BrowserTabViewModel)this.DataContext;
            viewModel.LastDownloadAction = downloadAction;
            viewModel.DownloadItem = downloadItem;
        });
        */
    }
    
    // ...
    
    public class DownloadHandler : IDownloadHandler
    {
        public event EventHandler<DownloadItem> OnBeforeDownloadFired;
        
        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;
        
        MainForm mainForm;
	    
        public DownloadHandler(MainForm form)
        {
            mainForm = form;
        }
    
        public void OnBeforeDownload(IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            var handler = OnBeforeDownloadFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }
    
            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }
    
        public void OnDownloadUpdated(IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            var handler = OnDownloadUpdatedFired;
            if (handler != null)
            {
                handler(this, downloadItem);
            }
        }
    }
    
    // ...
