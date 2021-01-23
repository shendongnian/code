       protected void CheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox.Checked == true)
        {
            gvPredbiljezbe.DataSourceID = dsGridView1.ID;
            gvPredbiljezbe.DataBind();
        }
    
        else
        {
            gvPredbiljezbe.DataSourceID = dsGridView2.ID;
            gvPredbiljezbe.DataBind();
    
        }
    }
