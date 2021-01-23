            lbl = (Label)this.Page.FindControl("lbltxt");
        }
        [WebMethod]
        public static List<string> lfromp(string id)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection("MYCONNECTIONSTRING");
            con.Open();
            SqlCommand cmd = new SqlCommand("SPlgfpro", con); //select login from profile
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            param = new SqlParameter("@id", id);
            param.DbType = DbType.String;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //dlstprofile.Items.Clear();
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    dlstprofile.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            //}
            con.Close();
            SqlCommand lfp = new SqlCommand("SPlgfpro");//select class from class
            lfp.CommandType = CommandType.StoredProcedure;
            lfp.Connection = con;
            SqlParameter dpra;
            dpra = new SqlParameter("@id", id);
            dpra.Direction = ParameterDirection.Input;
            dpra.DbType = DbType.String;
            lfp.Parameters.Add(dpra);
            con.Open();
            lfp.ExecuteNonQuery();
            SqlDataAdapter lda1 = new SqlDataAdapter(lfp);
            DataSet dds1 = new DataSet();
            lda1.Fill(dds1);
            SqlDataReader drlp = lfp.ExecuteReader();
            {
                if (drlp.Read())
                {
                    id = drlp["login"].ToString();
                }
                else
                {
                    Label l = lbl;
                    l.Visible = true;
                }
            }
            con.Close();
        }
    }
}
