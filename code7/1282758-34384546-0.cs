      public ObservableCollection<NdfClassViewModel> Classes
      {
          get { return _classes; }
      }
      public ICollectionView ClassesCollectionView
      {
          get
          {
              if (_classesCollectionView == null)
              {
                  BuildClassesCollectionView();
              }
               return _classesCollectionView;
          }
      }
      private void BuildClassesCollectionView()
      {
          _classesCollectionView = CollectionViewSource.GetDefaultView(Classes);
          _classesCollectionView.Filter = FilterClasses;
          OnPropertyChanged(() => ClassesCollectionView);
      }
      public bool FilterClasses(object o)
      {
          var clas = o as NdfClassViewModel;
     
          // return true if object should be in list with applied filter, return flase if not
      }
