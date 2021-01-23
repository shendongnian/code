    private Action B;
    private void Form1_Load()
    {
        if(B != null)
        {
            B();
        }
    }
    private void C()  
    {
        if (RadioButton.Checked == false)
        { B = D; }
        else 
        { B = E; }        
    }
