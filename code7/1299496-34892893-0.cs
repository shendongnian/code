    if (!IsPostBack)
    {
       BindDropDownList(); //Call this method
    }
    //Write a separate method to bind the dropdown
    private void BindDropDownList()
    {
        DataTable DtGoodType = new DataTable();
        ObjPriDaAdp = new OracleDataAdapter("select mkey, vehicle_no from XXCUS.XXGID_AUDIT_ENTRY where mkey= '" + Hid_MKey.Value + "'", ObjPriCon);
        ObjPriDaAdp.Fill(DtGoodType);
        if (DtGoodType.Rows.Count > 0)
        {
           cmdVehicleNo.DataTextField = "vehicle_no";
           cmdVehicleNo.DataValueField = "mkey";
           cmdVehicleNo.DataSource = DtGoodType;
           cmdVehicleNo.DataBind();
           cmdVehicleNo.Items.Insert(0, new ListItem("--- Select ---", "0"));
       }
    }
