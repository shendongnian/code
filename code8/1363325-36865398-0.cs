    public List<typVenda> getListaVendas(string dt_min, string dt_max)
    {
        List<typVenda> objVendaList = new List<typVenda>();
    
        using (SqlConnection con = new SqlConnection("connection String here"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.vcnosadesoes_getlistavendas", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
    
                while (dr.Read())
                {
    
                    var objVenda = new typVenda();
    
                    // Assign the values to the properties here
    
                    objVendaList.Add(objVenda);
                }
            }
        }
        return objVendaList;
    }
