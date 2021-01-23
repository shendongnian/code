    private GroupBoxController GBControl;
         
    private void Form1_Load(object sender, EventArgs e)
    {
         ......bunch of code here...
    
         GBControl = new GroupBoxController(groupbox1);
    
    }
    
    private void nextbutton_Click(object sender, EventArgs e)
    {
         GBControl.Whatever();
    }
