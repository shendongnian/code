    public TypeModel
    {
        private string _label;
        public string Label{ MVVM stuff}
        private UserControl _userControl;
        UserControl UserControl { MVVM stuff }
    }
    
    public class toto
    {
    private ObservableCollection<TypeModel> _list;
    public ObservableCollection<TypeModel> List
    {
    get{return this._list;}
    set { set value and notifyPropertyChanged }
    }
    
    private TypeModel _selectedItem;
    public TypeModel SelectedItem
    {
    get{ return this._selectedItem;}
    set { set value and NotifyPropertyChanged }
    }
    
    }
