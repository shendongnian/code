    protected void btnSearch2_Click(object sender, EventArgs e)
    {
        FillGrid1();
        Button1.Visible = true;
        GridView1.Visible = true; // <-- Add this
        DropDownList2.Enabled = false;
        DropDownList4.Enabled = false;
        chkImpacted.Enabled = false;
        chkSupporting.Enabled = false;
    }
