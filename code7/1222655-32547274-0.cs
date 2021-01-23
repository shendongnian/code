    public void total()
        {
            var tPrice=0;
            var tQuantity=0;
            var tAmount=0
            foreach (DataGridViewRow item in tbl_Purchase.Rows)
            {
                tPrice += (int.Parse(tbl_Purchase.Rows[item.Index].Cells[3].Value.ToString()));
                tQuantity += (int.Parse(tbl_Purchase.Rows[item.Index].Cells[4].Value.ToString()));
                tAmount += (int.Parse(tbl_Purchase.Rows[item.Index].Cells[5].Value.ToString()));    
            }
            l_Price.Text = (Convert.ToString(tPrice));
            l_Quantity.Text = (Convert.ToString(tQuantity));
            l_Amount.Text = (Convert.ToString(tAmount));
        }
