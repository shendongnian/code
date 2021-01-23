    // Declared at the form level
    private bool _modified = false;
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
         // Code that initializes the textboxes could raise the TextChanged event
         .....
         _modified = false;
    }
    private void OnBoxesChanged(object sender, EventArgs e)
    {
        _modified = true;
    }
    private void btnClose_Click(object sender, EventArgs e)
    {
        if(_modified)
        {
             // Save ....
        }
   
    }
