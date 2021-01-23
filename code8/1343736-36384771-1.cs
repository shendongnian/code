    private readonly ObservableAsPropertyHelper<bool> _isUserEditing;
    public ReactiveList<string> Operators { get; } = new ReactiveList<string>();
    public UserVm CurrentUser
    {
        get { return _currentUser; }
        set { this.RaiseAndSetIfChanged(ref _currentUser, value); }
    }
    public bool IsUserEditing => _isUserEditing.Value;
