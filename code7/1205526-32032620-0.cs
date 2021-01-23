    public bool displayed {get; set;}
    
    private void Form1_Load(object sender, EventArgs e)
    {
       displayed = false;
    }    
    
    private void Panel1_Paint(object sender, PaintEventArgs e)
    {
        if(!displayed) {
             // do paint functions
             displayed = true;
        }
    }
