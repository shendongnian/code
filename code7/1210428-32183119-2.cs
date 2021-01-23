    var cnn = new SqlConnection(SqlDataSource1.ConnectionString);
    var cmd = new SqlCommand("INSERT INTO Member (MemberJoinDate,DateOfBirth) VALUES (@MemberJoinDate,@DateOfBirth)", cnn);
    cmd.Parameters.Add("@MemberJoinDate", DateTime.Parse(Member.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture));
    cmd.Parameters.Add("@DateOfBirth", DateTime.Parse(MemberID.Text, "MM/dd/yyyy", System.Globalization.CultureInfo.CurrentCulture));
    try
    {
        cnn.Open();             
        cmd.ExecuteNonQuery();               
    }
    catch (Exception ex)
    {
        
        //Response.Write(ex); //probably shouldn't write directly to the response
        ClientScriptManager.RegisterStartupScript(this.GetType(), "InsertionError", "alert('Something went wrong while saving the data!')", true);
    }
    finally // this code will always get executed, even if there's a problem in the try block
    {
        cmd.Dispose();
        cnn.Close();
    }
    btn_Confirm.Visible = false;
