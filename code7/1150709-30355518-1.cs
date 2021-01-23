    public int num;
    public String value;
    
    public myControl(int num, String value)
    {
        InitializeComponent();
        this.num = num;
        this.value = value;
        InitializeTextboxes();
    }
       
    private void InitializeTextboxes()
    {
        sometextbox.Text = value;
        someothertextbox.Text = num.ToString();
    }
