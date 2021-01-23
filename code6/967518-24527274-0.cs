    private void btnUrediStavku_Click(object sender, EventArgs e)
    {
       if (dgvNoveStavke.SelectedRows.Count > 0)
       {
           dgvNoveStavke.SelectedCells[0].Value = txtIdStavke.Text;
           dgvNoveStavke.SelectedCells[1].Value = txtIzabranaStavka.Text;
           dgvNoveStavke.SelectedCells[2].Value = txtKolicina.Text;
           dgvNoveStavke.SelectedCells[3].Value = txtPopust.Text;
       }      
    }
