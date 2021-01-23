    class test{
    
    AnotherForm op;
    
    public test(){
      AnotherForm nForm = new AnotherForm(); //Starts a form object
      op = nForm; // Assigns the form to be shown to the non-local variable
      nForm.Show(); // shows the form object to user
      
    }
    
    private void menuItem1_Click(object sender, EventArgs e)
    {
      op.BringToFront(); //This will work
    }
    
    }
