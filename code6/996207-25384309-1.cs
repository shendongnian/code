    private ObservableCollection<DetailsViewModel> detailViewModels = new ObservableCollection<DetailsViewModel>();
        public ObservableCollection<DetailsViewModel> DetailViewModels
        {
            get { return detailViewModels; }
            set
            {
                if (Equals(value, detailViewModels)) return;
                detailViewModels = value;
                OnPropertyChanged();
            }
        }
        ...
