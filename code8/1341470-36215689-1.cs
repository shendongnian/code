    protected void GrdProspective1_UpdateCommand(object sender, Obout.Grid.GridRecordEventArgs e)
    {
        if (Session["grdEdit"] != null)
        {
            DtCombo = (DataTable)Session["grdEdit"];
        }
        else
        {
            return;
        }
    
        DataRow[] dataProsUpdate = DtCombo.Select("SR_NO = " + e.Record["SR_NO"]);
    
        dataProsUpdate[0]["PARTY_NAME"] = e.Record["PARTY_NAME"];
        dataProsUpdate[0]["FLAT_NO"] = e.Record["FLAT_NO"];
        dataProsUpdate[0]["LEASE_NUM"] = e.Record["LEASE_NUM"];
        dataProsUpdate[0]["ACTION"] = e.Record["ACTION"];
        dataProsUpdate[0]["NO_OF_DAYS"] = e.Record["NO_OF_DAYS"];
        dataProsUpdate[0]["REMARKS"] = e.Record["REMARKS"];
    
        GrdProspective1.DataSource = DtCombo;
        GrdProspective1.DataBind();
        AddToViewState("GrdProspective1");
    }
    public void DisplayGridEdit() 
    { 
    OracleCommand cmd = new OracleCommand("SELECT...", ObjPriCon); 
    
    DtCombo = new DataTable(); 
    OracleDataAdapter da = new OracleDataAdapter(cmd); 
    da.Fill(DtCombo); 
    
    GrdProspective1.DataSource = DtCombo; 
    GrdProspective1.DataBind(); 
    AddToViewState("GrdProspective1");
    }
