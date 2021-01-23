    public class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Entity() {
            Stats.PropertyChanged += Stats_PropertyChanged
        }
        //Other stuff.... 
        void Stats_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                e.PropertyName = "Stats." + e.PropertyName;
                PropertyChanged(this, e);
            }
        }
    }
