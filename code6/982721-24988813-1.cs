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
            // Check if the value gets parsed and is in range, otherwise show error and 
            //exit from this handler
            If (!diffTest || dblSalesTax < 0 || dblSalesTax > 25)  '<--- Change While to If
            {
    
                MessageBox.Show("Please enter a valid tax.");
                txtSalesTax.Clear();
    
                diffTest = false;
                return; // Return from here since validation failed
            }
    
            ... 
            ...
            ...
    }
