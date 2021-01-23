    public delegate void delegateName();
    
    public delegateName delMyFunction;
    
    private void MyFunction()
    {
    }
    
    private void Form_Load(object sender, EventArgs e)
    {
        delMyFunction =  new delegateName(this.MyFunction);
    }
