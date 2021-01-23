        public MTObservableCollection<int> NumbersCollection
        {
            get { return _item.NumbersCollection; }
        }
        public ICommand RandomizeCommand
        {
            get
            {
                if (_randomizeCommand == null)
                    _randomizeCommand = new RelayCommand(() =>
                    {                        
                        Task.Run(()=>
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                _dataService.Randomize();                                
                                Thread.Sleep(TimeSpan.FromSeconds(3));
                            }
                        });                        
                    });
                return _randomizeCommand;
            }
        }
