    <Window.Resources>
        <FrameworkElement x:Key="DCKey" />
    </Window.Resources>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            ((FrameworkElement)this.Resources["DCKey"]).DataContext = vm;
        }
    <MenuItem Header="DoSomething" Command="{Binding DataContext.Cmd, Source={StaticResource DCKey}}"/>
