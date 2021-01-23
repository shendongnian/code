    You could listen for the KeyUp event
    
    using System.Windows.Forms;
    
    private void btnSubmit_KeyUp(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Enter)
            MessageBox.Show("You hit the Enter key.");
    }
