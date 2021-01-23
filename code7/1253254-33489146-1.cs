        private Icon customCursor;
        public Form1()
        {
            InitializeComponent();
            customCursor = Properties.Resources.Cat;
            panel1.Cursor = panel2.Cursor = new Cursor(customCursor.Handle);
        }
