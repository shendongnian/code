    public class Input:Form 
    {
        private frmCodeGenerator myFrmCodeGenerator; // hold the caller
        // extra constructor
        public Input(frmCodeGenerator frm)
        {
           myFrmCodeGenerator = frm;
        }   
        private void cmdOkay_Click(object sender, EventArgs e)
        {
            // improve to use Int32.TryParse
            
            // call the method on our original form
            myFrmCodeGenerator.updateString(int.Parse(txtInput.Text));
            this.Hide();
        }
    }
