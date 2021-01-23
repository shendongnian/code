    public void Fill_List(List<string> fill_arry)
    {
        SqlDataReader objReader;
        SqlCommand objcmd =null;
    
        int i = 0;
    
        vsql = "SELECT [NOME] As Identificador,[RGP],[NOME],[ENDERECO],[CIDADE],[ESTADO],[TELEFONE],[CELULAR] FROM pescador";
    
        if (this.Conectar())
        {
            try
            {
                objcmd = new SqlCommand(vsql, objCon);
                objReader = objcmd.ExecuteReader();
    
                while (objReader.Read())
                {
                    //The value is added to List<string> fill_arry here.
                    fill_arry.Add(objReader.GetString(1));
                }
            }
            catch (SqlException erro)
            {
                throw erro;
            }
            finally
            {
                this.Desconectar();
            }
        }
    }
