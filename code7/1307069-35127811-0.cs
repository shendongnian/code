    protected void GetDatafortable1()
    {
        lblpltfrm_Number.Text = "PlatForm 1";
        list.InnerHtml = "";
        dv_FromStop.InnerHtml = "";
        Dv_ToStop.InnerHtml = "";
        dv_Time.InnerHtml = "";
        dv_status.InnerHtml = "";
        // int svalue = Convert.ToInt32(Session["ReloadValue"]);
        DataTable obj_Dt = new DataTable();
        OracleConnection obj_Connection = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["OracleConn"].ToString());
    
        string Query = "Select x.SR_NO,x.FROM_STOP,x.TO_STOP,x.ORIGIN_STOP_TIME from XXACL_PN_BUS_TIMETABLE x WHERE SCREEN_NUMBER=1";
        using (OracleCommand obj_Command = new OracleCommand(Query))
        {
            OracleDataAdapter obj_Adapter = new OracleDataAdapter(obj_Command);
            obj_Command.Connection = obj_Connection;
            obj_Adapter.SelectCommand = obj_Command;
            obj_Adapter.Fill(obj_Dt);
           ViewState["TimeTable"] = obj_Dt;
           ViewState["Index"] = 0; 
    
            //Data1Arrived = true;
        }
    }
    
    private void UpdateHtml()
    {
    DataTable dt = (DataTable) ViewState["TimeTable"]
    int index = (int) ViewState["Index"];
    for (int i = index; i <= index+1; i++)
            {
    
                list.InnerHtml = list.InnerHtml + "<br />" +
                     dt.Rows[i]["SR_NO"];
                dv_FromStop.InnerHtml = dv_FromStop.InnerHtml + "<br />" +
                   dt.Rows[i]["FROM_STOP"];
                Dv_ToStop.InnerHtml = Dv_ToStop.InnerHtml + "<br />" +
                    dt.Rows[i]["TO_STOP"];
                dv_Time.InnerHtml = dv_Time.InnerHtml + "<br />" +
                    dt.Rows[i]["ORIGIN_STOP_TIME"];
            }
    
    ViewState["Index"] = index+1;
    
    }
    
    proctected void page_load()
    {
       GetDatafortable1();
       UpdateHtml();
    
    }
     proctected void timer1_tick()
    {
    UpdateHtml();
    }
