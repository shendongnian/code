            string constring = GlobalClass.ConnectionStringGet();
            string sqlUpdate = "UPDATE  MemberDetails SET Active = '0'  WHERE Member_No = '" + txtmemberno.Text + "'";
            SqlConnection conDatabase = new SqlConnection(constring);
            SqlCommand cmdd = new SqlCommand(sqlUpdate, conDatabase);
            conDatabase.Open();
            cmdd.ExecuteNonQuery();
            conDatabase.Close();
            MessageBox.Show("Installment Close Successfully.");
