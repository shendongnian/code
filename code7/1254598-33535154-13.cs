    public Form2()
    {
        InitializeComponent();
        AddDynamicControls();
    }
    private void AddDynamicControls()
    {
        this.Controls.Add(
           new TextBox() { 
              Name = "TextBox1", Text = "Dynamic", Location = new Point(100, 0) });
    }
