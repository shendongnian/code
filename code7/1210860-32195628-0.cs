    try
    {
        SqlCommand cmd = new SqlCommand("Select distinct (stage) from tblStatus where EstimateID=@EstimateID", con);
        cmd.Parameters.AddWithValue("@EstimateID", Convert.ToInt32(listEstimateID.Text));
        lblStage.Text = cmd.ExecuteScalar().ToString();
    }
    catch (Exception exc)
    {
        MessageBox.Show(exc.Message);
    }
