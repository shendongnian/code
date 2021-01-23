        private ObservableCollection<Note> _entries;
    
        public ObservableCollection<Note> entries
        {
          get{return _entries;}
          set
          {
            _entries = value;
            RefinedEntries = new ObservableCollection(_entries.Where(e=>e.isActive).Select(e => e));
          }
    
         }
        
        public ObservableCollection<Note> refinedEntries {get;set;}
