                price = 10;
                tot = qty * price;
            }
            else if (DropDownList1.SelectedItem.Value == "1")
            {
                price = 20;
                tot = qty * price;
            }
            txtPrice.Text = tot.ToString();
