    private readonly Timer t;
    public Form1()
    {
        InitializeComponent();
        t = new Timer {Interval = 100};
        t.Tick += go;
        //t.Start();
        int[] myTab = functionThatReturnInts(1);
        Stopwatch test = new Stopwatch();
        test.Start();
        for (int i = 0; i < myTab.Length; i++)
        {
        }
        myTextBox.Text = test.Elapsed.ToString();
    }
    public int[] functionThatReturnInts(int desiredSize)
    {
        return Enumerable.Repeat(42, desiredSize).ToArray();
    }
