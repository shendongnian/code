    public partial class MainForm : Form,
        ITerminalView
    {
        private IGlobalTerminalPresenter globalTerminalPresenter;
        public MainForm()
        {
            InitializeComponent();
            var nextLevelPresenters = new KeyValuePair<String, ITerminalPresenter>[]
            {
                new KeyValuePair<String, ITerminalPresenter>(
                    "A plus B", 
                    new APlusBPresenter(this)),
                new KeyValuePair<String, ITerminalPresenter>(
                    "Just empty selector", 
                    new SelectOptionPresenter(this, 
                        "Selector with no selection choices", 
                        Enumerable
                            .Empty<KeyValuePair<String, ITerminalPresenter>>()
                            .ToArray()))
            };
            var topPresenter = new SelectOptionPresenter(this, "Select the option and press the confirm button",  nextLevelPresenters);
            this.globalTerminalPresenter = new GlobalTerminalPresenter(topPresenter);
        }
