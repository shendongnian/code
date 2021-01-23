    public class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string TestImageAspect
        {
            get { return testImageAspect; }
            set
            {
                testImageAspect = value;
                if (PropertyChanged != null)
                {
                   PropertyChanged(this, new PropertyChangedEventArgs("TestImageAspect"));
                }
            }
        }
        private string testImageAspect;
    }
