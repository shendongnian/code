     public Insight3DPluginControl(Insight3DPlugin plugin, MapViewModel viewModel)
        : base(plugin)
        {
            InitializeComponent();
            Insight3DPluginControl theControl = this;
            RXMouse = new RXMapMouse(theControl);
            eob_tool = new EOBTool(RXMouse);
         }
