    protected Inventory GetSelectedProduct()
        {
            try
            {
                if (ddlProducts.Items.Count == 0)
                {
                    // do nothing, fall thru will return null
                }
                else
                {
                    string[] DDLValue = ddlProducts.SelectedValue.Split('|');
                    int ivalue = 0;
                    int.TryParse(DDLValue.GetValue(0).ToString(), out ivalue);
                    decimal dvalue = 0.00m;
                    decimal.TryParse(DDLValue.GetValue(2).ToString(), out dvalue);
                    // only return object if the productid and product price were successfully parsed.
                    // this logic assumes no products are free
                    if (ivalue > 0 && dvalue > 0.00m)
                    {
                        return new Inventory(ivalue, DDLValue.GetValue(1).ToString(), dvalue);
                    }
                }
            }
            catch { }
            return null;
        }
