    private void btnBook_Click(object sender, EventArgs e)
    {
        if (cmbDeaprture.Text.Equals(cmbDestination.Text)){
            MessageBox.Show("Cannot have the same Destination as Departure");
        }
    }
