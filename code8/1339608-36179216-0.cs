    class Object {
      string Description {get;set;}
      decimal UnitPrice {get;set;}
    }
    Dictionary<string, Object> _dict = new Dictionary<string, Object>();
    void Load() 
    {
        string connstr = "user id=rawpic;password=admin";
        string cmdtxt = @"select PRODUCT_ID,DESCRIPTION,UNIT_PRICE from products";
        AutoCompleteStringCollection autocom = new AutoCompleteStringCollection();
        TB_PRODUCT_ID.AutoCompleteMode = AutoCompleteMode.Suggest;
        TB_PRODUCT_ID.AutoCompleteSource = AutoCompleteSource.CustomSource;
        TB_PRODUCT_ID.AutoCompleteCustomSource = autocom;       
        using (OracleConnection conn = new OracleConnection(connstr))
        using (OracleCommand cmd = new OracleCommand(cmdtxt, conn))
        {
            try
            {
                conn.Open();
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    _dict.Add(dr["PRODUCT_ID"], new Object() { Description = dr["DESCRIPTION"], UnitPrice = dr["UNIT_PRICE"] };
                    autocom.Add(dr["PRODUCT_ID"].ToString());
                }
            }
            catch(Exception ex)
            {
                // handle exception
            }
        }
    }
    private void TB_PRODUCT_ID_TextChanged(object sender, EventArgs e)
    {
	if (_dict.ContainsKey(e.Text)) // may not be e.text just guessed :) 
        {
            TB_PRODUCTS_KEY.Text = _dict[e.Text].Description;
            TB_UNIT_PRICE.Text = _dict[e.Text].UnitPrice.ToString();
        }
    }
