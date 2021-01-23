    // Declared at the form level
    private bool _modified = false;
    public Form1()
    {
        InitializeComponent();
        // This could be done in the form designer of course 
        // o repeated here for every textbox involved....
        txtName.TextChanged += OnBoxesChanged;
        ......
    }
    private void Form1_Load(object sender, EventArgs e)
    {
         .....
         // Code that initializes the textboxes could raise the TextChanged event
         // So it is better to reset the global variable to an untouched state
         _modified = false;
    }
    private void OnBoxesChanged(object sender, EventArgs e)
    {
        // Every textbox will call this event handler
        _modified = true;
    }
    private void btnClose_Click(object sender, EventArgs e)
    {
        if(_modified)
        {
             // Save, warning, whatever in case of changes  ....
        }
   
    }
