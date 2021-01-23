        public partial class WebForm1 : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddlFaculty.Items.Count == 0)
            {
                ddlFaculty.DataSource = GetFaculty();
                ddlFaculty.DataTextField = "LastName";
                ddlFaculty.DataValueField = "FacultyId";
                ddlFaculty.DataBind();
            }
        }
        private DataTable GetFaculty()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FacultyId", typeof(int));
            dt.Columns.Add("LastName", typeof(string));
            var dr1 = dt.NewRow();
            dr1["FacultyId"] = 1;
            dr1["LastName"] = "Smith";
            dt.Rows.Add(dr1);
            var dr2 = dt.NewRow();
            dr2["FacultyId"] = 2;
            dr2["LastName"] = "Jones";
            dt.Rows.Add(dr2);
            return dt;
        }
        private DataTable GetDept(int facultyId)
        {
            var dt = new DataTable();
            dt.Columns.Add("DeptId", typeof(int));
            dt.Columns.Add("DeptName", typeof(string));
            switch (facultyId)
            {
                case 1:
                    var dr = dt.NewRow();
                    dr["DeptId"] = 1;
                    dr["DeptName"] = "Administration";
                    dt.Rows.Add(dr);
                    break;
                case 2:
                    var dr1 = dt.NewRow();
                    dr1["DeptId"] = 2;
                    dr1["DeptName"] = "Science";
                    dt.Rows.Add(dr1);
                    break;
            }
            return dt;
        }
        protected void ddlFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedValue = ddlFaculty.SelectedValue;
           
            ddlDept.Items.Clear();
            ddlDept.DataSource = GetDept(Convert.ToInt16(selectedValue));
            ddlDept.DataTextField = "DeptName";
            ddlDept.DataValueField = "DeptId";
            ddlDept.DataBind();
            
        }       
       
    }
