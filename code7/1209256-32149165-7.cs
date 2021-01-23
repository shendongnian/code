    public sealed class ExampleA : UserControl, IHandle<EnableButtonMessage>
    {
        ...
        public ExampleA()
        {
            this.InitializeComponent();
            EventAggregator.Instance.Subscribe(this);
        }
        ...
        public void Handle(EnableButtonMessage message)
        {
            this.OKButton.IsEnabled = true;
        }
        ...
    }
