    [WebMethod]
     public static string GetRef(int id)
     {
         DataTable dt = new DataTable();
         SqlParameter[] p = new SqlParameter[1];
         p[0] = new SqlParameter("@RefID", id);
         dt = dl.GetDataWithParameters("Sp_WT_GetRef", p);
         string data = dt.Rows[0]["Description"].ToString() +"|"+ dt.Rows[0]["PriceInUSD"].ToString();
         return data;
     }
