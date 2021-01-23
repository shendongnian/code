        public  ObservableCollection<int> NumbersCollection
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
                        //Task.Run(() =>
                        DispatcherHelper.RunAsync(async () =>
                        {
                            for (var i = 0; i < 10; i++)
                            {
                                _dataService.Randomize();
                                //Thread.Sleep(TimeSpan.FromSeconds(3));
                                await Task.Delay(TimeSpan.FromSeconds(3));
                            }
                        });
                    });
                return _randomizeCommand;
            }
        }
