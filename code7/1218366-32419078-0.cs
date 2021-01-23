    public void Search_IDFicha(int param_IDFICHA, List<string> list_peixe, List<string> list_quant, List<string> list_peso)
        {
            SqlDataReader objReader;
            SqlCommand objcmd = null;
    
            vsql = "SELECT [ID_FICHA], [RGP], [PEIXE], [PESO], [QUANTIDADE], [DATA_REGISTRO] FROM cadastro WHERE ID_FICHA = @ID_FICHA";
            if (this.Conectar())
            {
                try
                {
                    objcmd = new SqlCommand(vsql, objCon);
    
                    objcmd.Parameters.Add(new SqlParameter("@ID_FICHA", param_IDFICHA));
    
                    objReader = objcmd.ExecuteReader();
    
                    while (objReader.Read())
                    {
                        valor.retorna_IdFIcha = objReader.GetInt32(0);
                        list_peixe.Add(objReader.GetString(2));
                        list_peso.Add(objReader.GetDouble(3).ToString());
                        list_quant.Add(objReader.GetInt32(4).ToString());
                    }
                }
                catch
                {
    
                }
                finally
                {
                    this.Desconectar();
                }
            }
    
        }
