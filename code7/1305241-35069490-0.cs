    class AudioPlayer
    {
        private static string _tempFolder; 
        private static string _filename;
        private string _musicPath;
        public WindowsMediaPlayer _wmp;
        public AudioPlayer()
        {
            _tempFolder = Path.GetTempPath();
            _filename = "Music1.mp3";
            _musicPath = Path.Combine(_tempFolder,_filename);
            CopyResource(_musicPath, Resources.Music1);
            _wmp = new WindowsMediaPlayer();
            _wmp.URL = _musicPath;
            
        }
        private void CopyResource(string resourceName, byte[] file)
        {
            File.WriteAllBytes(resourceName, file);
        }
        public void Play()
        {
            _wmp.controls.play();
        }
        public void Stop()
        {
            _wmp.controls.stop();
        }
    }
