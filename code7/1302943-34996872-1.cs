         int quantity;
            if (int.TryParse(cmbQuantity.Text, out quantity))
            {
                SqlCommand inventorycontrol = new SqlCommand("Update Product SET quantityAvailable=quantityAvailabe - @Quantity WHERE productName=@prodName", con);
                inventorycontrol.Parameters.AddWithValue("@Quantity", Convert.ToInt32());
                inventorycontrol.Parameters.AddWithValue("@prodName", cmbProdName.Text);
                //Execue command here
            }
            else
            {
                // show message invalid quantity
            }
