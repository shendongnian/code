    private CheckBox[] _checkBoxes;
    public Form1() // Constructor
    {
        InitializeComponent();
        _checkBoxes = Controls
            .OfType<CheckBox>()
            .Where(cb => cb.Name.StartsWith("Id"))
            .OrderBy(cb => cb.Name)
            .ToArray();
    }
