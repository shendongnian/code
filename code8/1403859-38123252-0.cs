    string sql = "UPDATE CostT SET tFormSent = @selection1,TName = @UserName,FormDate = @FormDate where ReqNum = @ReqNum";
    cmd = new OleDbCommand(sql, con22);
    cmd.Parameters.Add("@selection1", Selection1.Text);
    cmd.Parameters.Add("@UserName", UserName.Text);
    cmd.Parameters.Add("@FromDate", FromDate.Text);
    cmd.Parameters.Add("@ReqNum", ReqNum.Text);
    cmd.ExecuteNonQuery();
    con22.Close();
