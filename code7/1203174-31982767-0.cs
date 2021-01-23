    public class InnerViewWithButton : UserControl
    {
        public InnerViewWithButton()
        {
            InitializeComponent();
            InnerButton.Click+=(sender,args)=>RaiseInnerButtonClicked();
        }
        public event EventHandler InnerButtonClicked;
        private void RaiseInnerButtonClicked()
        {
            var clickHandlers = InnerButtonClicked;
            if (clickHandlers != null) clickHandlers(this, EventArgs.Empty);
        }
    }
    public class InnerViewWithMethod : UserControl
    {
        ...ctor...
        public void DoSomeMagic()
        {
            ...
        }
    }
    public class OuterView : UserControl
    {
        public OuterView()
        {
            InitializeComponent();
            MyInnerViewWithButton.InnerButtonClicked +=
                (sender,args) => MyInnerViewWithMethod.DoSomeMagic();
        }
    }
