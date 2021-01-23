            private ObservableCollection<InspectionUrgencyDetailViewModel> _externalInspections;
            public ObservableCollection<InspectionUrgencyDetailViewModel> ExternalInspections
            {
                get { return _externalInspections; }
                set { Set(() => ExternalInspections, ref _externalInspections, value); }
            }
    
            private ObservableCollection<InspectionUrgencyDetailViewModel> _internalInspections;
            public ObservableCollection<InspectionUrgencyDetailViewModel> InternalInspections
            {
                get { return _internalInspections; }
                set { Set(() => InternalInspections, ref _internalInspections, value); }
