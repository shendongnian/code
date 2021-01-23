    <TextBox x:Name="tbName" DataContext="{Binding ResultData}" Text="{Binding Name}" />
///
    public partial class MainWindow : Window
    {
        public MainWindow()
        {  
            InitializeComponent();
            ShellViewModel vm = new ShellViewModel();
            vm.CreateObject();
            this.DataContext = vm;
        } 
        ...
