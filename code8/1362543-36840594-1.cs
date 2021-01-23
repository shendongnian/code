    private string Name {get;set;}
    private int Score {get;set;}
    public Form3(string name, int score)
    {
        InitializeComponent();
        this.Name = name;
        this.Score = score;
    }
    public Form3() : this("defaultName", 0)
    { }
