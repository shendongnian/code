    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int gridColumn;
        public int GridColumn
        {
            get { return gridColumn; }
            set { gridColumn = value; OnPropertyChanged(); }
        }
        private int gridRow;
        public int GridRow
        {
            get { return gridRow; }
            set { gridRow = value; OnPropertyChanged(); }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
