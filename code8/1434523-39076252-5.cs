    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        vm.Nodes.Add(new TextNode
        {
            XPos = 50,
            YPos = 100,
            Text = "Hello, World."
        });
        vm.Nodes.Add(new ShapeNode
        {
            XPos = 100,
            YPos = 200,
            Geometry = new EllipseGeometry { RadiusX = 50, RadiusY = 50 },
            Fill = Brushes.Red
        });
        DataContext = vm;
    }
