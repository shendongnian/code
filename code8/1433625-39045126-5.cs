    public Form1() //Form constructor.
    {
        InitializeComponent();
        textBox1.KeyPress += textBox1_KeyPress;
        textBox1.KeyDown += textBox1_KeyDown;
    }
    bool InputIsCommand = false;
    private void textBox1_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if(e.Control == true && (e.KeyCode == Keys.V || e.KeyCode == Keys.C))
        {
            InputIsCommand = true;
        }
    }
    private void textBox1_KeyPress(Object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        e.Handled = !InputIsCommand;
    }
