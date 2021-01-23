       namespace Stack
    {
        public class PictureViewer : INotifyPropertyChanged
        {
           private const string PictureDirectory = @"C:\Users\TMoore\Pictures";
            public int CurrentPictureNumber { get; set; }
    
            private string currentImagePath;
            public string CurrentImagePath
            {
                get { return currentImagePath; }
                set
                {
                    currentImagePath = value;
                    OnPropertyChanged();
                }
            }
    
            private IList<string> pictureList { get; set; }
            public IList<string> PictureList
            {
                get { return pictureList ?? (pictureList = new List<string>()); }
                set { pictureList = value; }
            }
    
            public PictureViewer()
            {
                // you should add a search pattern
                pictureList = Directory.EnumerateFiles(PictureDirectory)
                                       .ToList();
                CurrentImagePath = pictureList[0];
            }
    
            public void Next()
            {
                CurrentImagePath = CurrentPictureNumber > pictureList.Count() - 1
                    ? PictureList[0]: PictureList[CurrentPictureNumber++];
            }
    
            public void Previous()
            {
                CurrentImagePath = CurrentPictureNumber == 0
                    ? PictureList[PictureList.Count()-1] : PictureList[CurrentPictureNumber--];
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
