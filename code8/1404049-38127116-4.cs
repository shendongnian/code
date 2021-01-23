    public void textBox1_TextChanged(object sender, EventArgs e)
    {
        //This does nothing. You are creating a variable whose scope is just
        // this method, so you wouldn't be able to access it from outside
        string var;
        var = textBox1.Text;
     }
     private void button_OK_Click(object sender, EventArgs e)
     {
         Form1 myForm = new Form1(); //You are creating a new Form1..Why?
         
         //there won't be a dialogResult,as you are not showing the form with ShowDialog
         if(myForm.DialogResult == DialogResult.OK) 
         {
             MessageBox.Show("You have successfully added this entry to the key files.");
             // object MessageBoxButtons = new MessageBoxButtons;
             // MessageBoxButtons.OK = this.Close();               
         }
    }
    private void button_Cancel_Click(object sender, EventArgs e)
    {    
         Form1 myForm = new Form1();
         if(myForm.DialogResult == DialogResult.Cancel)
         {
         //   this.Close();
            Application.Exit();
         }
    }
