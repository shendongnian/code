    protected void capture()
        {
            string CS = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(CS))
            {
                conn.Open();
    
                SqlCommand com = new SqlCommand();
                SqlParameter myParam = new SqlParameter();
    
                //Insert records into the office table                
                com.CommandText = "INSERT into Offices(Office_Number, Status, Building, Branch, Floor) VALUES (@Office_Number, @Status, @Building, @Branch, @Floor)";
                com.Parameters.AddWithValue("@Office_Number", txtOffNo.Text);
                com.Parameters.AddWithValue("@Status", ddlOStatus.Text);
                com.Parameters.AddWithValue("@Building", ddlBuilding.Text);
                com.Parameters.AddWithValue("@Branch", ddlBranch.Text);
                com.Parameters.AddWithValue("@Floor", ddlFloors.Text);
                com.Connection = conn;
                com.ExecuteNonQuery();
                com.Parameters.Clear();
    
                com.CommandText = "select max(Office_Id) from Offices";
                int officeid = Convert.ToInt32(com.ExecuteScalar());
    
                com.CommandText = "INSERT into Member(officeid,Appointment_Number, Initials, Surname, Designation) VALUES (@officeid,@Appointment_Number, @Initials, @Surname, @Designation)";
                com.Parameters.AddWithValue("@officeid", officeid);
                com.Parameters.AddWithValue("@Appointment_Number", txtAppointmentNumber.Text);
                com.Parameters.AddWithValue("@Initials", txtInitials.Text);
                com.Parameters.AddWithValue("@Surname", txtSurname.Text);
                com.Parameters.AddWithValue("@Designation", ddlDesignation.Text);
                com.Connection = conn;
                com.ExecuteNonQuery();
                com.Parameters.Clear();
    
                if (IsPostBack)
                {
                    Response.Redirect("~/Pages/MemberDetails.aspx");
    
                }
            }        
        }
