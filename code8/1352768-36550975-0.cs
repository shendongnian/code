    string documentsPath = ApplicationData.Current.LocalFolder.Path;
            
            System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
            Task.Factory.StartNew(async () =>
            {
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("Data");
                mre.Set();
            });
            mre.WaitOne();
