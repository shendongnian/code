    public class AudioService 
    {
        #region Members
        protected AVPlayer Player;
        #endregion
        #region Properties
        public bool IsPlaying { get; private set; }
        public bool HasFile => Player != null;
        public Action MediaEnded { get; set; }
        #endregion
        #region Public Methods
        public void PlayStream(string uri)
        {
            try
            {
                if (Player != null)
                    Player.Dispose();
                Player = null;
                QueueFile(uri);
                Player.Play();
                IsPlaying = true;
            }
            catch (Exception ex)
            {
                IsPlaying = false;
                Crashes.TrackError(ex);
            }
        }
        public void Pause()
        {
            IsPlaying = false;
            Player.Pause();
        }
        public void Stop()
        {
            IsPlaying = false;
            if (Player == null)
                return;
            Player.Dispose();
            Player = null;
        }
        public void QueueFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return;
            }
            using (var url = NSUrl.FromString(fileName))
            {
                var asset = AVAsset.FromUrl(url);
                var playerItem = AVPlayerItem.FromAsset(asset);
                if (Player == null)
                {
                    Player = AVPlayer.FromPlayerItem(playerItem);
                    if (Player == null)
                    {
                        return;
                    }
                    else
                    {
                        NSNotificationCenter.DefaultCenter.AddObserver(AVPlayerItem.DidPlayToEndTimeNotification, OnPlayerDidFinishPlaying, NSObject.FromObject(playerItem));
                    }
                }
            }
        }
        #endregion
        #region Private Methods
        private void OnPlayerDidFinishPlaying(NSNotification notification)
        {
            IsPlaying = false;
            MediaEnded?.Invoke();
        }
        #endregion
