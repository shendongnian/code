    public class SomeVm : INotifyPropertyChanged
    {
        // INPC implementation is omitted
        public IEnumerable<SomeType> Items { get; }
        public SomeType SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                    // do what you want, when property changes
                }
            }
        }
    }
