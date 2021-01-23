    private void btnAddItem_Click(object sender, EventArgs e)
    {
        //Declare variables
        double dblSalesTax = 0, dblPrice, dblTax, dblSalesPrice;
        string strItem, strTaxAdded;
        int intQuantity;
        bool diffTest = false;
    
        //Process user input
    
    
            //While (!diffTest)
            //{
              diffTest = double.TryParse(txtSalesTax.Text, out dblSalesTax);
            //}   
            If (!diffTest || dblSalesTax < 0 || dblSalesTax > 25)  '<--- Change While to If
            {
    
                MessageBox.Show("Please enter a valid tax.");
                txtSalesTax.Clear();
    
                diffTest = false;
                return; // Return from here since validation failed
            }
    
    
            intQuantity = Convert.ToInt16(txtQuantity.Text);
            dblPrice = Convert.ToDouble(txtPrice.Text);
            dblSalesPrice = dblPrice * intQuantity;
            strItem = cbxItem.Text;
            intQuantity = Convert.ToInt16(txtQuantity.Text);
    
            dblSubtotal += dblSalesPrice;
    
            if (chkTaxExempt.Checked)
            {
                dblTax = 0;
                strTaxAdded = "";
            }
            else
            {
                dblTax = dblSalesPrice * dblSalesTax;
                strTaxAdded = "*";
    
            }
            dblTaxTotal += dblTax;
    
            lbxTally.Items.Add(strItem + ", " + dblSalesPrice.ToString("C") + strTaxAdded);
    
            //Reset Form
    
            txtPrice.Clear();
            txtQuantity.Clear();
            chkTaxExempt.Checked = false;
            cbxItem.Focus();
    }
