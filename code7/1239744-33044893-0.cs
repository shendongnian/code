    public void existType()
    {
        try
        {
            using (var conn = new SqlConnection())
            {
                conn.Open();
                string existquery = "SELECT*FROM tblRoomType WHERE Type = '" + txtRoomType.Text + "'";
                da = new OleDbDataAdapter(existquery, conn);
                da.Fill(ds, "tblRoomType");
            }
            //rest of code
        }
    }
    public void editRoomType()
    {
        using (var conn = new SqlConnection())
        {
            conn.Open();
            string edittypequery = "UPDATE tblRoomType SET Rate = '" + txtRoomRate.Text + "', ExtraCharge = '" + txtExtraCharge.Text + "', CancelFee = '" + txtCancelFee.Text + "', MaxOcc = '" + txtMaxOcc.Text + "' WHERE TypeID = '" + txtRoomType.Text + "'";
            cmd = new OleDbCommand(edittypequery, conn);
            cmd.ExecuteNonQuery();
        }
    }
