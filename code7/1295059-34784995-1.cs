    public class User : PropertyChangedBase
    {
        private bool isSelected;
    
        public int Id { get; set; }
        public string Name { get; set; }
            
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
                    NotifyOfPropertyChange<bool>(() => IsSelected);
                }
            }
        }
    }
