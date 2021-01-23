    private void cb_Bolge_SelectedValueChanged(object sender, EventArgs e)
    {
        if (cb_Bolge.SelectedIndex != -1)
        {
            cb_Departman.DataSource = k.tbl_Departmans.Where(p=>p.Bolge_ID == Convert.ToInt32(cb_Bolge.SelectedValue));
            cb_Departman.DisplayMember = "Departman_Ad";
            cb_Departman.ValueMember = "Departman_ID";
        }
    }
