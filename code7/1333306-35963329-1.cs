    [System.ComponentModel.DefaultEvent("ButtonClicked")]
    public partial class SampleControl: UserControl
    {
        public SampleControl()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }
    
        public event EventHandler ButtonClicked;
        protected virtual void OnButtonClicked(EventArgs e)
        {
            var handler = ButtonClicked;
            if (handler != null)
                handler(this, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Do Stuff then raise event
            OnButtonClicked(EventArgs.Empty);
        }
    }
