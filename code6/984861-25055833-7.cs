    public class Input:Form 
    {
        frmCodeGenerator f = new frmCodeGenerator();
    
        private void cmdOkay_Click(object sender, EventArgs e)
        {
            f.updateString(int.Parse(txtInput.Text));
            this.Hide();
        }
    }
