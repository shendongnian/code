    public class Global : System.Web.HttpApplication
        {
            protected void Application_Start(object sender, EventArgs e)
            {
                RegisterRoute(RouteTable.Routes);
            }
    
            public void RegisterRoute(RouteCollection routes)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("T");
                dt.Columns.Add(new DataColumn("Head", typeof(string)));
                dt.Columns.Add(new DataColumn("Desc", typeof(string)));
                dt.Columns.Add(new DataColumn("Url", typeof(string)));
    
                DataRow dr0 = dt.NewRow();
                dr0["Head"] = "Default";
                dr0["Desc"] = "D/D";
                dr0["Url"] = "~/Default.aspx";
                dt.Rows.Add(dr0);
    
                DataRow dr1 = dt.NewRow();
                dr1["Head"] = "ERP1";
                dr1["Desc"] = "ERP/ERP1";
                dr1["Url"] = "~/ERP/ERP1.aspx";
                dt.Rows.Add(dr1);
    
                DataRow dr2 = dt.NewRow();
                dr2["Head"] = "ERP2";
                dr2["Desc"] = "ERP/ERP2";
                dr2["Url"] = "~/ERP/ERP2.aspx";
                dt.Rows.Add(dr2);
    
                DataRow dr3 = dt.NewRow();
                dr3["Head"] = "W";
                dr3["Desc"] = "W/W";
                dr3["Url"] = "~/WebForm1.aspx";
                dt.Rows.Add(dr3);
    
                foreach (DataRow d in dt.Rows)
                {
                    routes.MapPageRoute(d["Head"].ToString(), d["Desc"].ToString(), d["Url"].ToString());
                }
            }
        }
