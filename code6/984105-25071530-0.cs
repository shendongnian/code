        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("Select * FROM Collections_New WHERE Collection_Code LIKE '" + prefixText + "%'", conn);
        DataSet ds = new DataSet();
        SqlDataAdapter dta = new SqlDataAdapter(cmd);
        dta.Fill(ds);
        conn.Close();
        List<string> CollectionCodes = new List<string>();
          for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
          {
              CollectionCodes.Add(ds.Tables[0].Rows[i]["Collection_Code"].ToString());
          }
          return CollectionCodes;
    }
