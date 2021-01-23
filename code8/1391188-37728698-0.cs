            myCommandUpd = new SqlCommand(updateCmd, DataBase.GetConnetionToBase());
            myCommandUpd.Parameters.Add(new SqlParameter("@Emplid", SqlDbType.VarChar, 10));
            myCommandUpd.Parameters.Add(new SqlParameter("@RecId", SqlDbType.BigInt));
            myCommandUpd.Parameters["@Emplid"].Value = emplIdUpd.Text.Trim();
            myCommandUpd.Parameters["@RecId"].Value = Convert.ToInt64(RecIdUpd.Value.Trim());
            myCommandUpd.Connection.Open();
            myCommandUpd.ExecuteNonQuery();
