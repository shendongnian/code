    private MainViewModel m_ViewModel = new MainViewModel();
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = m_ViewModel;
        var keyGesture = new KeyGesture(Key.N, ModifierKeys.Control);
        var keyBinding = new KeyBinding(m_ViewModel.NewCommand, keyGesture);
        this.InputBindings.Add(keyBinding);
    }
