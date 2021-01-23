    protected void ddlUnit_OnSelectedIndexChanged(object sender, EventArgs e)
    {   
        string flatstatus = ddlUnit.SelectedItem.Text;
        OracleConnection ObjPriCon = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OracleConn"].ToString());
        ObjPriCon.Open();
        OracleCommand cmd = new OracleCommand("Select distinct FLAT_STATUS STATUS from xxacl_pn_flat_det_v where FLAT_ID = '" + flatstatus + "' order by STATUS", ObjPriCon);
        if (ddlUnit.SelectedItem.Text.ToString().Equals("--- Select ---"))
        {
            txtstatus.Value = "";
            return;
        }
        OracleDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {
            dr.Read();
            txtstatus.Value = dr["STATUS"].ToString();
        }
        else
        {
            
        }
        dr.Close();
        ObjPriCon.Close();
        DisplayGrid();
        GrdBookingStatus.Visible = true;
    }
