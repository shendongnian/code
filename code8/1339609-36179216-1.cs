    public class MyObject {
      string Description {get;set;}
      decimal UnitPrice {get;set;}
    }
    public Dictionary<string, MyObject> _dict = new Dictionary<string, MyObject>();
    public void Load() 
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
                    _dict.Add(dr["PRODUCT_ID"], new MyObject() { Description = dr["DESCRIPTION"], UnitPrice = dr["UNIT_PRICE"] };
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
    
	if (_dict.ContainsKey(TB_PRODUCT_ID.Text))  
        {
            TB_PRODUCTS_KEY.Text = _dict[TB_PRODUCT_ID.Text].Description;
            TB_UNIT_PRICE.Text = _dict[TB_PRODUCT_ID.Text].UnitPrice.ToString();
        }
    }
