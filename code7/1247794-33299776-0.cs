            string contractName = gvShowData.DataKeys[e.RowIndex].Value.ToString();
            GridViewRow row = (GridViewRow)gvShowData.Rows[e.RowIndex];
            TextBox txtContractName = (TextBox)row.FindControl("Contract");
            string txtCName = row.Cells[1].Text.ToString();
            string txtModel = row.Cells[2].Text.ToString();
            string txtProcess = row.Cells[3].Text.ToString();
            var list = new List<string>();
            for(int cell = 4; cell < 28; cell++)
            {
                list.Add((row.Cells[cell].Controls[0] as TextBox).Text.ToString());
            }
            gvShowData.EditIndex = -1;
            con.Open();
            DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:mm:ss.fff";
            string commandString = "INSERT INTO dms (Contract, Line, Process, H0,H1,H2,H3,H4,H5,H6,H7,H8,H9,H10,H11,H12,H13,H14,H15,H16,H17,H18,H19,H20,H21,H22,H23,timestamp,username) VALUES('" + txtCName + "','" + txtModel + "','" + txtProcess + "','" + list[0] + "','" + list[1] + "','" + list[2] + "','" + list[3] + "','" + list[4] + "','" + list[5] + "','" + list[6] + "','" + list[7] + "','" + list[8] + "','" + list[9] + "','" + list[10] + "','" + list[11] + "','" + list[12] + "','" + list[13] + "','" + list[14] + "','" + list[15] + "','" + list[16] + "','" + list[17] + "','" + list[18] + "','" + list[19] + "','" + list[20] + "','" + list[21] + "','" + list[22] + "','" + list[23] + "','" + System.DateTime.Now.ToString(format) + "','" + User.Identity.Name.ToString() + "')";
            SqlCommand com = new SqlCommand(commandString, con);
            com.ExecuteNonQuery();
            con.Close();
            BindGridView();
