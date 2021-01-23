    public Form1()
    {
            InitializeComponent();
            // Indicate this form would explicitly support transparency
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            // Make your label transparent
            label1.BackColor = Color.Transparent;
    }
   
