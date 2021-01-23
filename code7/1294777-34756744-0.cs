    public  class TasksViewModel : ViewModelBase
    {
        public IEnumerable<ViewModelBase> Collection => _collection;
        public override string ViewModelName => "Tasks";
        public TasksViewModel()
        {
            _collection = new ObservableCollection<ViewModelBase>
                          {
                              new ImportUsersViewModel(),
                              new TestFunctionsViewModel()
                          };
            // watch for currentstatus property changes in the internal view models and use those for our status
            foreach (var i in _collection)
            {
                 i.PropertyChanged += this.InternalCollectionPropertyChanged;
            }
        }
      }
      //
      // if a currentstatus property change occurred inside one of the nested
      // viewmodelbase objects, set our status to that status
      //
      private InternalCollectionPropertyChanged(object source, PropertyChangeEvent e)
      {
          var vm = source as ViewModelBase;
          if (vm != null && e.PropertyName = nameof(CurrentStatus))
          {
               this.CurrentStatus = vm.CurrentStatus;
          }
      }
