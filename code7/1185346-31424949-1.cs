    private void cb_Bolge_ValueMemberChanged(object sender, EventArgs e)
    {
       int blogId=Convert.ToInt32(cb_Bolge.SelectedValue);
       cb_Departman.DataSource = k.tbl_Departmans.Where(p=>p.Bolge_ID == blogId);
       cb_Departman.DisplayMember = "Departman_Ad";
       cb_Departman.ValueMember = "Departman_ID";
    }
