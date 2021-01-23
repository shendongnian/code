     GridViewRow row = gv_dalamkota.SelectedRow;           
           
            System.Web.UI.WebControls.DropDownList ddl_jenis_kuitansi= row.FindControl("lblName") as System.Web.UI.WebControls.DropDownList;
           
        if (ddl_jenis_kuitansi.SelectedValue == "1")
        {
            Response.Redirect("dalamkota_rincian_dua.aspx");
        }
        else if (ddl_jenis_kuitansi.SelectedValue == "2")
        {
            Response.Redirect("dalamkota_rincian_satu.aspx");
        }
    
