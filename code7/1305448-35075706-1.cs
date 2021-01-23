    using(var adapter =  new SqlDataAdapter("SELECT Extended_Description, Design_Service_Fashion_Name_BESTBUY_CA, Width_cm, Height_cm, Shippable_Depth_cm, Shippable_Weight_grams, Depth_cm, Weight_grams FROM master_Design_Attributes WHERE Design_Service_Code = \'" + design + "\';", connection))
    {
            connection.Open();
            adapter.Fill(table);
            for (int i = 0; i <= 7; i++)
            {
                list.Add(table.Rows[0][i].ToString());
            }
            table.Reset();
            adapter = new SqlDataAdapter("SELECT SKU_BESTBUY_CA, UPC_Code_9, UPC_Code_10, Base_Price FROM master_SKU_Attributes WHERE SKU_Ashlin = \'" + sku + "\';", connection);
            adapter.Fill(table);
            for (int i = 0; i <= 3; i++)
            {
                list.Add(table.Rows[0][i].ToString());
            }
    }
            connection.Dispose();
