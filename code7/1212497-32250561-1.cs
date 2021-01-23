    public class DataModel : NotifyPropertyChangedImpl
    {
        private string dynamicDescription;
    
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Code { get; set; }
    
        public string DynamicDescription
        {
            get
            {
                return dynamicDescription;
            }
            set
            {
                if (dynamicDescription != value)
                {
                    dynamicDescription = value;
                    OnPropertyChanged("DynamicDescription");
                }
            }
        }
    }
