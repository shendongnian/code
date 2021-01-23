        private void btnAdd_Click(object sender, EventArgs e)
        {
            string product = txtProduct.Text;
            decimal price = Convert.ToDecimal(txtPrice.Text);
            bool price_found = false;
            for (int i = 0; i < lstProductPriceBox.Items.Count; i++)
            {
                if (lstProductPriceBox.Items[i].ToString().Contains(product + " ="))
                {
                    string x = lstProductPriceBox.Items[i].ToString().Substring(lstProductPriceBox.Items[i].ToString().IndexOf("=") + 1).Replace("$","");
                    decimal current_total = Convert.ToDecimal(x);
                    lstProductPriceBox.Items[i] = product + " = " + (price +  current_total).ToString("c");
                    price_found = true;
                }
            }
            if(!price_found)
                lstProductPriceBox.Items.Add(product + " = " + price.ToString("c"));
        }
