    public void updateActivityLead()
            {
                SqlConnection con = new SqlConnection(OpSupLib.MyConnectionString);
                SqlCommand cmd = new SqlCommand();
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
    
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[activity].[udpUpdateActivityLead]";
    
                SqlParameter p1 = new SqlParameter();
                p1.ParameterName = "@ActivityLeadTable";
                p1.Value = getDataGridID();
                cmd.Parameters.Add(p1);
    
                SqlParameter p2 = new SqlParameter();
                p2.ParameterName = "@OwnerTo";
                p2.Value = ((ComboBoxItem)cmbUpdateTo.SelectedItem).HiddenValue;
                cmd.Parameters.Add(p2);
    
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
