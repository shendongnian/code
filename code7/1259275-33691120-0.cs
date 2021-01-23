    public class Filter : NotifyPropertyChangedBase
    {
        private bool isSelected;
        private string description;
    
        public Filter(string description)
        {
            this.description = description;
        }
    
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (StringComparer.Ordinal.Compare(description, value) != 0)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
    
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }
    }
