    try
    {
        SqlCommand cmd = new SqlCommand("Select distinct (stage) from tblStatus where EstimateID=@EstimateID", con);
       
        int id;
    
        if(int.TryParse(listEstimateID.Text, out id)
        {
            cmd.Parameters.AddWithValue("EstimateID", id );
        }
        else  MessageBox.Show("Invalid Estimate ID");
    
        lblStage.Text = cmd.ExecuteScalar().ToString();
    }
    catch (Exception exc)
    {
        MessageBox.Show(exc.Message);
    }
