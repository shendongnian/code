    public bool stkMaintain()
        {
            SqlDataReader drd;
            var qty = 0;
            SqlCommand cmd = new SqlCommand("SELECT * from StockMstrDetail where ItemId='" + Convert.ToString(txtScanBarcode.Text) + "'", con);
            //cmd.CommandType = CommandType.Text;
            con.Open();
            drd = cmd.ExecuteReader();
            if (drd.HasRows)
            {
                while (drd.Read())
                {
                    qty = Convert.ToInt32(drd["Quantity"].ToString());
                }
                if (Convert.ToInt32(txtentrqty.Text) > (Convert.ToInt32(qty)))
                {
                    Response.Write("Product Not In Stock...!);
                }
                if(txtentrqty.Text=="")
                {
                    Response.Write("Quantity Should not be blank...!");
                    Con.Close();
                    return false;
                }
            }
            con.Close();
            return true;
        }    
