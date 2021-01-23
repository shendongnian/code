        public ReactiveCommand<object> EnterCmd { get; private set; }
        ObservableAsPropertyHelper<bool> _isLoading;
        public bool IsLoading { get { return _isLoading.Value; } }
        public MainViewModel()
        {
            EnterCmd = ReactiveCommand.Create(
                this.WhenAny(x => x.UserID, x => x.Value)
                    .Select(x => !String.IsNullOrWhiteSpace(x)));
            EnterCmd.IsExecuting.ToProperty(this, x => x.IsLoading, out _isLoading);
            EnterCmd.Subscribe(x =>
            {
                Console.WriteLine(x);
            });
