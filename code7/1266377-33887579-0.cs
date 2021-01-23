    public List<yourClass> GetData()
    {
    using (SqlConnection con = new SqlConnection(Global.Config.ConnStr))
    {
      
        DataTable dt = new DataTable();
        List<yourClass> details = new List<yourClass>();
        SqlCommand cmd = new SqlCommand("spp_adm_user_user_group_sel", con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
         foreach(DataRow dr in dt.Rows)
                {
                    yourClass obj = new yourClass();
                    obj.exmaple = dr["exmaple"].ToString();
                    obj.age = dr["age"].ToString();
                   
                    details.Add(obj);
                }
                
                return details;
            }
}
