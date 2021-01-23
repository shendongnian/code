    private Color _filledColor;
    public ColorTextBox()
    {
        InitializeComponent();
        _filledColor = Color.FromKnownColor(KnownColor.Control);
    }
    public Color FilledColor
    {
        get { return _filledColor; }
        set
        {
            _filledColor = value;
            button1.BackColor = _filledColor;
        }
    }
