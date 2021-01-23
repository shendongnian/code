     private void dgvList_MouseClick(object sender, MouseEventArgs e)
            {
                    tbName.Text = dgvList.SelectedRows[0].Cells[0].Value.ToString();
                    tbSurname.Text = dgvList.SelectedRows[0].Cells[1].Value.ToString();
                    tbMobile.Text = dgvList.SelectedRows[0].Cells[2].Value.ToString();
                    tbEmail.Text = dgvList.SelectedRows[0].Cells[3].Value.ToString();
                    cbCategory.Text = dgvList.SelectedRows[0].Cells[4].Value.ToString();
            }
