    public ProductFamily[] GetListProductFamily()
    {
        List<ProductFamily> arrayProductFamily = List<ProductFamily>();
        IConnection conn = ConnUtil.GetConnection();
        string query = GET_QUERY;
        try
        {
            var dataReader = conn.ExecuteReader(query);
            while (dataReader.Read())
            {
                ProductFamily productFamily = new ProductFamily();
                productFamily.cIdProductFamily = DB.LoadString(dataReader, "CIDPRODUCTFAMILY");
                productFamily.cProductFamily = DB.LoadString(dataReader, "CPRODUCTFAMILY");
                productFamily.lActive = Convert.ToInt32(DB.LoadInt(dataReader, "LACTIVE"));
                arrayProductFamily.Add(productFamily);
            }
        }
        catch (Exception ex)
        {
            Logger.Error("Error", ex);
        }
        return arrayProductFamily.ToArray();
    }
