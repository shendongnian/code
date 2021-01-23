    <DataTemplate x:Key="GenericList3StateCheckbox">
        <CheckBox IsThreeState="True" Checked="FilterChanged" Unchecked="FilterChanged" Content="{Binding Caption}" IsChecked="{Binding State}"/>
    </DataTemplate>
    List<FilterItemVM> LvGenres = new List<FilterItemVM>();
    public class FilterItemVM : INotifyPropertyChanged
    {
        private string _caption;
        public string Caption
        {
            get { return _caption; }
            set
            {
                _caption= value;
                OnPropertyChanged();
            }
        }
        private bool? _state;
        public bool? State
        {
            get { return _state; }
            set
            {
                _state= value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
