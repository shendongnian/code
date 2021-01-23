    //In your first forms(so form1) button handler
    using(Form3 form3 = new Form3()) 
    {
      if(form3.ShowDialog() == DialogResult.OK) 
      {
        someControlOnForm1.Text = form3.TheValue;
      }
    }
    //In Form3
    
    //Define public property to serve value
    
    public string TheValue 
    {
      get { return someTextBoxOnForm2.Text; }
    }
