    public void Init()
    {
        InitializeComponent();
        InitializeMyGLControl();
        InitializeMyScrollBar();
        InitializeMouseEvents();
        InitializeKeyboardControls();
        InitializeContextMenu();
        InitializeComboBox();
        InitializeToolStripView();
        InitializeListBox();
        setToDefaultScale();
    }
    public ViewDigiFiles()
    {
        Init();
    }
    public ViewDigiFiles(List<SelectDataLog.DataLog> d)
    {
        datalogList = d;
        Init();
    }
