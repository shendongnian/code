	protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
	{
		string loginID = (String)Session["UserID"];
		string ID = txtID.Text;
		string password = txtPassword.Text;
		string name = txtName.Text;
		string position = txtPosition.Text;
		int status = 1;
		string createOn = validate.GetTimestamp(DateTime.Now); ;
		string accessRight;
		if (RadioButton1.Checked)
			accessRight = "Administrator";
		else
			accessRight = "Non-administrator";
		if (txtID.Text != "")
			ClientScript.RegisterStartupScript(this.GetType(), "yourMessage", "alert('" + ID + "ha " + password + "ha " + status + "ha " + accessRight + "ha " + position + "ha " + name + "ha " + createOn + "');", true);
		string strQuery;
		OleDbCommand  cmd;
		strQuery = "INSERT INTO USERMASTER(USERID,USERPWD,USERNAME,USERPOISITION,USERACCESSRIGHTS,USERSTATUS,CREATEDATE,CREATEUSERID) VALUES(@ID,@password,@name,@position,@accessRight,@status,@createOn,@loginID)";
		cmd = new OleDbCommand(strQuery);
		cmd.Parameters.AddWithValue("@ID", ID);
		cmd.Parameters.AddWithValue("@password", password);
		cmd.Parameters.AddWithValue("@name", name);
		cmd.Parameters.AddWithValue("@position", position);
		cmd.Parameters.AddWithValue("@accessRight", accessRight);
		cmd.Parameters.AddWithValue("@status", status);
		cmd.Parameters.AddWithValue("@createOn", createOn);
		cmd.Parameters.AddWithValue("@loginID", loginID);
		bool isInserted =  readdata.updateData(cmd);
	}
