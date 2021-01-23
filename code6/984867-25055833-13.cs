    public class Input:Form 
    {
        frmCodeGenerator f = new frmCodeGenerator();
    
        private void cmdOkay_Click(object sender, EventArgs e)
        {
            f.updateString(int.Parse(txtInput.Text));
            // this will Show your newly created Form but now you have two of them...
            f.Show(); 
            this.Hide();
        }
    }
