    public void Bind_TimeSlots()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_GETAPPOINTMENTTIME", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@drid", SqlDbType.VarChar).Value = hdfid.Value;
            cmd.Parameters.Add("@APPTDATE", SqlDbType.VarChar).Value = txtdate.Text;
            SqlDataReader drAppointmentTimings = cmd.ExecuteReader();
            rbtTimeSlots.DataSource = drAppointmentTimings;
            rbtTimeSlots.Items.Clear();
            rbtTimeSlots.DataTextField = "TimeSlot";
            rbtTimeSlots.DataValueField = "id";
            rbtTimeSlots.DataBind();
            con.Close();
        }
        
        protected void btnAppointmentTime_Click(object sender, EventArgs e)
        {
        string selectedval = rbtTimeSlots.SelectedItem.Text; //if by value then SelectedValue.ToString()
            Bind_TimeSlots();
        if (rbtTimeSlots.Items.FindByText(selectedval) != null)  //if by value then rbtTimeSlots.Items.FindByValue(selectedval)()
               {              
                   rbtTimeSlots.Items.FindByText(selectedval).Selected = true;  
                   rbtTimeSlots.Items.FindByText(selectedval).Enabled = false;  
               }  
        }
