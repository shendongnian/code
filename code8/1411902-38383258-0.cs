    public class Student : INotifyPropertyChanged
    {
        private int semesterScore;
    
        public int SemesterScore
        {
            get { return semesterScore; }
            set
            {
                semesterScore = value; 
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public class Semester : INotifyPropertyChanged
    {
        private int score;
    
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
