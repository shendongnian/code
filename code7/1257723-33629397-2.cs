    public class PriceListViewModels<TViewType> : IViewModel where TViewType : IView,  new () 
        {
            private readonly IView _view;
    
            private readonly PriceListModel _modelPriceListModel;
            private readonly PriceModel _modelPriceModel;
            private readonly NewServInPriceListModel _modelNewServInPriceListModel;
    
            public ObservableCollection<PriceList> PriceListObservableCollection { get; set; }
            public ObservableCollection<Price> PriceObservableCollection { get; set; }
            public ObservableCollection<NewServInPriceList> NewServObServableCollection { get; set; }
    
            public RelayCommand CommandSave { get; private set; }
    
    
            // создаем объект ICollection View, для отображения и фильтрации данных в Datagrid
            public ICollectionView collview { get; private set; }
    
            public ObservableCollection<bool> Colec { get; set; }
    
    
            #region fields
            private string _textBoxSearch;  // переменная которая связана с TextBoxSearch во View
            private DateTime _dateTimeBeginPriceList; 
            private DateTime _dateTimeEndPriceList;
            private int _selectedIndexListBox;
            private string _textBoxComment;
            private string _contentButtonDisplaySearch;
    
            // переменные для выбора типов оплаты
            private bool _omsIsChecked;
            private bool _dmsIsChecked;
            private bool _budshetIsChecked;
            private bool _platnoIsChecked;
    
            private bool _displayRadioButton;
            private bool _searchRadionButton;
    
            #endregion
    
            #region Constructors
            public PriceListViewModels()
            {
                this._view = new TViewType();
    
                this._modelPriceListModel = new PriceListModel();
                this.PriceListObservableCollection = new ObservableCollection<PriceList>(this._modelPriceListModel.GetService());
    
                this._modelPriceModel = new PriceModel();
                this.PriceObservableCollection = new ObservableCollection<Price>(this._modelPriceModel.GetPrice());
    
                this._modelNewServInPriceListModel = new NewServInPriceListModel();
                this.NewServObServableCollection = new ObservableCollection<NewServInPriceList>(this._modelNewServInPriceListModel.GetNewServ());
                this.CommandSave = new RelayCommand(o => this.OKRun());
    
    
                // присваиваем collview observable collection 
                collview = (CollectionView)CollectionViewSource.GetDefaultView(NewServObServableCollection);
    
                // задаем начальные значения для DateTimePicker
                _dateTimeBeginPriceList = DateTime.Today.AddDays(-1);
                _dateTimeEndPriceList =  new DateTime(2016, 05, 28);
    
                _displayRadioButton = true;
    
                _contentButtonDisplaySearch = "Найти";
                        
                this._view.SetDataContext(this);
                this._view.ShowIView();
            }
