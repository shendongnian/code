    protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
    {
        btn_submit.Visible = true;
        lbl_nama.Text = GridView1.SelectedRow.Cells[1].Text;
        ....
    }
