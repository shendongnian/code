    public Form1()
    {
        InitializeComponent();
        panel1.AllowDrop = true;
        panel1.DragEnter += panel_DragEnter;
        panel1.DragDrop += panel_DragDrop;
        panel1.DragOver += panel_DragOver;
        button1.MouseDown += button1_MouseDown;
    
    }
    
    private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        button1.DoDragDrop(button1, DragDropEffects.Copy | DragDropEffects.Move);
    }
