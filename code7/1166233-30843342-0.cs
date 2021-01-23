    private void LoadAsync(object sender, DoWorkEventArgs e)
        {
            BitmapDecoder decoder;
            using (Stream imageStreamSource = new FileStream(ImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                decoder = BitmapDecoder.Create(imageStreamSource, BitmapCreateOptions.PreservePixelFormat,
                    BitmapCacheOption.OnLoad);
            }
            foreach (var frame in decoder.Frames)
            {
                frame.Freeze();
                (sender as BackgroundWorker).ReportProgress(0, frame);
            }
        }
        private void UpdateAsync(object send, ProgressChangedEventArgs e)
        {
                SyncImages.Add((BitmapSource)e.UserState);
                OnPropertyChanged("SyncImages");
            
        }
