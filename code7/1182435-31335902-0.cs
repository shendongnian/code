    protected void btnEditSO_Click(object sender, EventArgs e)
    {
        panelSO.Visible = true;
        btnFinalizeSO.Text = " Update ";
    
        Button but = (Button)sender;
        GridViewRow grid = (GridViewRow)but.NamingContainer;
    
        string select_sql_SOddl = "SELECT ID, (LASTNAMER | | ' ' | | FIRSTNAMER ) AS REFERENTNAME FROM REFERENT_SHIPPING WHERE ID=" + grid.Cells[14].Text;
    
        using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString()))
        {
            con.Open();
            OracleCommand cmd = new OracleCommand(select_sql_SO, con);
            OracleCommand cmd1 = new OracleCommand(select_sql_SOddl, con);
            OracleDataReader dr = cmd.ExecuteReader();
            OracleDataReader dr1 = cmd1.ExecuteReader();
            
            int i=0;
            while (dr1.Read())
            {
                ddlReferentShip.Items.Add(dr[i].ToString());
                i++;
             // ddlReferentShip.Items.Add(dr["REFERENTNAME"].ToString());
             //   ddlReferentShip.DataSource = dr1;
            //    ddlReferentShip.DataTextField = dr1["REFERENTNAME"].ToString();
            //    ddlReferentShip.DataValueField = dr1["ID"].ToString();               
            //    ddlReferentShip.DataBind();
            }
    
        }
    
    }
