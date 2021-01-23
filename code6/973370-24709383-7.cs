    //FormA
    FormB myForm = new FormB();
    public void button1_click(object sender, EventArgs e)
    {        
        if (myForm != null && myForm.IsDisposed == false)
        {
            myForm.Value1 = textBox1.Text;
            myForm.Value2 = textBox1.Text;        
        }
    }
