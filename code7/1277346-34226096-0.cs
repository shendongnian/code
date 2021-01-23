    public class Map
    {
        Map(object item, MapAdapter adapter)
        {
            ...
            adapter.PropertyChanged += this.AdapterPropertyChanged;
        }
    
        private void AdapterPropertyChanged(object sender, PropertyChangedEventArg e)
        {
            if (e.PropertyName == "IsLayerVisible")
            {
                // Do something
            }
        }
    }
