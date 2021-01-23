    public class HighlightableChar : NotifyPropertyChangedImpl
    {
        private readonly char sourceChar;
        private bool isHighlighted;
    
        public HighlightableChar(char value)
        {
            sourceChar = value;
        }
    
        public char SourceChar
        {
            get
            {
                return sourceChar;
            }
        }
    
        public bool IsHighlighted
        {
            get
            {
                return isHighlighted;
            }
            set
            {
                if (isHighlighted != value)
                {
                    isHighlighted = value;
                    OnPropertyChanged("IsHighlighted");
                }
            }
        }
    }
