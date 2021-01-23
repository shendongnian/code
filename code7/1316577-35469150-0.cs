    public class VacationHelper
    {
        public static void FillVacations(System.Web.UI.WebControls.DropDownList ddl)
        {
            DataTable dt = DAL.Vacation.GetVacationTypes();
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataTextField = "vac_name";
            ddl.DataValueField = "vac_code";
            ddl.DataBind();
    
            ListItem item = new ListItem("-SELECT-", "-1");
            ddl.Items.Insert(0, item);
        }
    }
