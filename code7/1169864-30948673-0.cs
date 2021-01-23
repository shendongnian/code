    private void WriteToDatabase()
        {
            Guid newGuid = Guid.NewGuid();
            string yearstring = DateTime.Now.Year.ToString();
            string twodigityear = yearstring.Substring(yearstring.Length - 2);
            string dateAndGuid = twodigityear + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString() + "-" + newGuid;
            int Registree_Index;
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                string insertQuery = "INSERT INTO registrees (UIDindex, Submission_Number, Homecoming_Form, HC_form, NewRecord, First_Name, Last_Name, Billing_Phone, Addresses_Same, Email) VALUES (@UIDindex, @Submission_Number, @Homecoming_Form, @HC_form, @NewRecord, @First_Name, @Last_Name, @Billing_Phone, @Addresses_Same, @Email)               SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@UIDindex", dateAndGuid);
                    cmd.Parameters.AddWithValue("@Submission_Number", 1);
                    cmd.Parameters.AddWithValue("@Homecoming_Form", 1);
                    cmd.Parameters.AddWithValue("@HC_form", "platform");
                    cmd.Parameters.AddWithValue("@NewRecord", 1);
                    cmd.Parameters.AddWithValue("@First_Name", First_Name.Text);
                    cmd.Parameters.AddWithValue("@Last_Name", Last_Name.Text);
                    cmd.Parameters.AddWithValue("@Billing_Phone", Phone.Text);
                    cmd.Parameters.AddWithValue("@Addresses_Same", 1);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    ///get index from scope identity
                    Registree_Index = Convert.ToInt32(cmd.ExecuteScalar());
                }
                string insertQuery2 = "INSERT INTO event_registration (Registree_Index, UIDindex, Submission_Number) VALUES (@Registree_Index, @UIDindex, @Submission_Number)";
                using (SqlCommand cmd = new SqlCommand(insertQuery2, connection))
                {
                    cmd.Parameters.AddWithValue("@Registree_Index", Registree_Index);
                    cmd.Parameters.AddWithValue("@UIDindex", dateAndGuid);
                    cmd.Parameters.AddWithValue("@Submission_Number", 1);
                    cmd.ExecuteNonQuery();
                }
            }
        }
