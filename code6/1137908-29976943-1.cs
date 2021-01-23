    private int N = 3;
    private TextBlock[,] gridText;
    public MainPage()
    {
        this.InitializeComponent();
        InitializeGridText();
    
        MethodThatChangesText();
    }
    
    private void InitializeGridText()
    {
        gridText = new TextBlock[N, N];
        gridText[0, 0] = r1c1;
        gridText[0, 1] = r1c2;
        gridText[0, 2] = r1c3;
        gridText[1, 0] = r2c1;
        gridText[1, 1] = r2c2;
        gridText[1, 2] = r2c3;
        gridText[2, 0] = r3c1;
        gridText[2, 1] = r3c2;
        gridText[2, 2] = r3c3;
    }
    
    void MethodThatChangesText()
    {
        // Some Logic Here
    
        for(int i = 0; i < N; i++)
            for(int j = 0; j < N; j++)
                gridText[i, j].Text = String.Format("Row{0}Col{1}", i + 1, j + 1);
    }
