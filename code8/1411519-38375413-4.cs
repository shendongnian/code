            jpyRATE = 1.4;
            DataTable subjects = new DataTable();
            if (Page.IsPostBack == false)
            {
                using (SqlConnection con = new SqlConnection(constring))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT VehicleMake FROM VehicleDB", con);
                    adapter.Fill(subjects);
                    con.Open();
                    DropDownList1.DataSource = subjects;
                    DropDownList1.DataTextField = "VehicleMake";
                    DropDownList1.DataValueField = "VehicleMake";
                    DropDownList1.DataBind();
                    if(!String.IsNullOrEmpty(Session["vehiclemake"] as string)) 
{
    DropDownList1.SelectedIndex =
    DropDownList1.Items.IndexOf(DropDownList1.Items.FindByValue(Session["vehiclemake"].ToString()));
