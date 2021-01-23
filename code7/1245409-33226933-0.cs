    public class ListMulti : ParamType
    {
        [XmlArray("ListMultiItems")]
        [XmlArrayItem("Pair")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string[][] SerializableListMultiItems
        {
            get
            {
                return ListMultiItems.ToPairArray();
            }
            set
            {
                ListMultiItems.SetFromPairArray(value);
            }
        }
        [XmlArray("SelectedItemsListMulti")]
        [XmlArrayItem("Pair")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string[][] SerializableSelectedItemsListMulti
        {
            get
            {
                return SelectedItemsListMulti.ToPairArray();
            }
            set
            {
                SelectedItemsListMulti.SetFromPairArray(value);
            }
        }
        private ObservableCollection<Tuple<string, string>> _listMultiItems = new ObservableCollection<Tuple<string, string>>();
        [XmlIgnore]
        public ObservableCollection<Tuple<string, string>> ListMultiItems
        {
            get { return _listMultiItems; }
            set { SetProperty(ref _listMultiItems, value); }
        }
        private ObservableCollection<Tuple<string, string>> _selectedListMulti;
        [XmlIgnore]
        public ObservableCollection<Tuple<string, string>> SelectedItemsListMulti
        {
            get { return _selectedListMulti ?? (_selectedListMulti = new ObservableCollection<Tuple<string, string>>()); }
            set
            {
                SetProperty(ref _selectedListMulti, value);
            }
        }
    }
