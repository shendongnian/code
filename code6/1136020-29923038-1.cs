    public partial class MyTypeControl : UserControl
    {
        private MyType _MyType;
        private Label labelBirthday;
        private Label labelName;
        private Label labelSeparator;
        public MyTypeControl()
        {
            InitializeComponent();
        }
        public event EventHandler MyTypeChanged;
        public MyType MyType
        {
            get { return _MyType; }
            set
            {
                if (_MyType == value)
                    return;
                _MyType = value ?? MyType.Empty;
                OnMyTypeChanged(EventArgs.Empty);
            }
        }
        protected virtual void OnMyTypeChanged(EventArgs eventArgs)
        {
            UpdateVisualization();
            RaiseEvent(MyTypeChanged, eventArgs);
        }
        protected void UpdateVisualization()
        {
            SuspendLayout();
            labelName.Text = _MyType.MyName;
            labelBirthday.Text = _MyType.MyBirthday.ToString("F");
            labelBirthday.Visible = _MyType.MyBirthday != DateTime.MinValue;
            ResumeLayout();
        }
        private void InitializeComponent()
        {
            labelName = new Label();
            labelBirthday = new Label();
            labelSeparator = new Label();
            SuspendLayout();
            labelName.Dock = DockStyle.Top;
            labelName.Location = new Point(0, 0);
            labelName.TextAlign = ContentAlignment.MiddleCenter;
            labelBirthday.Dock = DockStyle.Top;
            labelBirthday.TextAlign = ContentAlignment.MiddleCenter;
            labelSeparator.BorderStyle = BorderStyle.Fixed3D;
            labelSeparator.Dock = DockStyle.Top;
            labelSeparator.Size = new Size(150, 2);
            Controls.Add(labelSeparator);
            Controls.Add(labelBirthday);
            Controls.Add(labelName);
            MinimumSize = new Size(0, 48);
            Name = "MyTypeControl";
            Size = new Size(150, 48);
            ResumeLayout(false);
        }
        private void RaiseEvent(EventHandler eventHandler, EventArgs eventArgs)
        {
            var temp = eventHandler;
            if (temp != null)
                temp(this, eventArgs);
        }
    }
