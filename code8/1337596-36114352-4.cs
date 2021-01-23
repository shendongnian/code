    public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
    
    
                var commandBar = new CommandBar();
                commandBar.VerticalAlignment = VerticalAlignment.Bottom;
                var appBarButton = new AppBarButton() { Icon = new SymbolIcon(Symbol.Accept), Label = "Accept" };
                commandBar.PrimaryCommands.Add(appBarButton);
    
                root.Children.Add(commandBar);
            }
        }
