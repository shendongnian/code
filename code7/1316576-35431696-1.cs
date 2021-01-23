    public partial class Vacationpage: System.Web.UI.Page
    {
            //define atttributes
            public Vacationpage()
            {
            }
            private void FillVacations()
            { 
            DataTable dt = DAL.Vacation.GetVacationTypes();
            ddl_vac_type.Items.Clear();
            ddl_vac_type.DataSource = dt;
            ddl_vac_type.DataTextField = "vac_name";
            ddl_vac_type.DataValueField = "vac_code";
            ddl_vac_type.DataBind();
            ListItem item = new ListItem("-SELECT-", "-1");
            ddl_vac_type.Items.Insert(0, item);
            }        
    }
