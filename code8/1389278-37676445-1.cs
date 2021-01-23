    DualCombo dc = new DualCombo();
    public Form1()
    {
        InitializeComponent();
        this.Controls.Add(dc);
        dc.SomeEvent += (s, e) => MyMethod(); // call your method
    }
