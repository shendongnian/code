    public static List<Perfil> DeletePerfil(string numeroPersonal)
    {
           
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT nombre FROM [Portal_B2e].[dbo].[usuarios] WHERE numero_personal = @PersNo", con);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@PersNo";
                param.Value = numeroPersonal;
                cmd.Parameters.Add(param);
             ...
            }
    }
