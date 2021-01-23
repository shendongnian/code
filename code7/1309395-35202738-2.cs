    private RelayCommand<Tuple<object,object>> _mobieDetailCommand;
        public RelayCommand<Tuple<object, object>> MobieDetailCommand
        {
            get
            {
                return _mobieDetailCommand
                    ?? (_mobieDetailCommand = new RelayCommand<Tuple<object, object>>(
                    (tuple) =>
                    {
                        var mobileInfo=tuple.Item1 as MobileModelInfo;
                        var os=tuple.Item2.ToString();                        
                        //Your logic
                    }));
            }
        }
