    //Declare variable for storing user string
    string username = "xxx";
    
    string reenable_query= string.Format("Exec procedure_name @parameter = {0}",username);
    
    SqlCommand rep_com = new SqlCommand(reenable_query, con_db_reenable);
        try
        {
            SqlDataAdapter sda1 = new SqlDataAdapter();
            sda1.SelectCommand = rep_com;
            DataTable dbdataset1 = new DataTable();
            sda1.Fill(dbdataset1);
            //Show Message *Add here
            string show = string.Format("The query has been executed successfully for the user {0}", username);
    
            MessageBox.Show(show);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error");
        }
    
    
    
