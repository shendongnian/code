    public class GalleryItem
    {
        public object Content { get; set; }
        
        public bool IsSelected 
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    
                    // TODO: do something here, when item becomes selected/checked; 
                    // handle property changing instead of commands
                }
            }
        }
        private bool isSelected;
    }
