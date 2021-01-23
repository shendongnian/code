        DB = new DBFunctions();
        string vItems = mGetSelectedItems();
        string vQuery = "Update  laminationtitle Set title='" + txtLaminationTitle.Text + "',laminationtypeid='" + ddlProductType.SelectedValue + "' where laminationid='" + Request.QueryString["laminationid"] + "'";
        int x = DB.SetData(vQuery);
        DataTable dSelect = new DataTable();
        DataTable dAll = new DataTable();
        DB = new DBFunctions();
        DB1 = new DBFunctions();
        if (x > 0)
        {
            int y = DB.SetData("delete from laminationtitlepapertyperelation where lamtitleid=" + Request.QueryString["laminationid"]);
            if (y > 0)
            {
                string[] values = vItems.Split(',');
                for (int i = 0; i < values.Length; i++)
                {
                    vQuery = "insert into laminationtitlepapertyperelation(lamtitleid, papertypeid, activestatus)VALUES('" + Request.QueryString["laminationid"].ToString() + "','" + values[i] + "',1)";
                    DB.SetData(vQuery);
                    ScriptManager.RegisterStartupScript(this, GetType(), " Update Lamination Title", "alert('Lamination " + '"' + txtLaminationTitle.Text + '"' + " Title Updated Sucessfully');window.location='ManageLaminationTitle.aspx';", true);
                }
            }
        }
    }
