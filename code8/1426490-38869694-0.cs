        public class MainGridDataContext:BaseObservableObject
        {
        private readonly ILikeEventAggregator _sharedService;
        //here we inject the the interface
        public MainGridDataContext(ILikeEventAggregator sharedService)
        {
            _sharedService = sharedService;
            //listen to selection changed
            _sharedService.PopupGridSelectionHandler += SharedServiceOnPopupGridSelectionHandler;
        }
        //uncomment next c'tor if you don't have any injection mechanism,
        //you should add the SharedService property to the App class
        //public MainGridDataContext()
        //{
        //    //_sharedService = App.Current.
        //    var app = Application.Current as App;
        //    if (app != null)
        //    {
        //        _sharedService = app.LikeEventAggregator;
        //        _sharedService.PopupGridSelectionHandler += SharedServiceOnPopupGridSelectionHandler;
        //    }
        //}
        private void SharedServiceOnPopupGridSelectionHandler(object sender, PopupGridData popupGridData)
        {
            UpdateGridWithAPopupSelectedData(popupGridData);
        }
        //method that helps to update the grid, you can do that in multiple ways
        private void UpdateGridWithAPopupSelectedData(PopupGridData popupGridData)
        {
            //Update your DataGrid here.
        }
    }
    public class PopupDataContext:BaseObservableObject
    {
        private readonly ILikeEventAggregator _sharedService;
        //here we inject the the interface
        public PopupDataContext(ILikeEventAggregator sharedService)
        {
            _sharedService = sharedService;
        }
        //uncomment next c'tor if you don't have any injection mechanism,
        //you should add the SharedService property to the App class
        //public PopupDataContext()
        //{
        //    //_sharedService = App.Current.
        //    var app = Application.Current as App;
        //    if (app != null)
        //    {
        //        _sharedService = app.LikeEventAggregator;
        //    }
        //}
        //... your logic
        private PopupGridData _selectedData;
        //you should bind the popup grid selected value to this property
        public PopupGridData SelectedData
        {
            get { return _selectedData; }
            set
            {
                _selectedData = value;
                OnPropertyChanged(() => SelectedData);
                _sharedService.OnPopupGridSelectionHandler(_selectedData);
            }
        }
        //... your logic
    }
    public class PopupGridData
    {
        public object PopupGridSelectedData { get; set; }
    }
