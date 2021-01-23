    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double Quantity,Price,sum;
        bool canProcess=true;
        if(!double.TryParse(txtQuantity.Text,out Quantity)
        {
          // conversion failed
          lblPriceToBe.Text="Invalid quantity"
          canProcess=false;
        }
        if(!double.TryParse(lblPriceToBe.Text,out Price)
        {
          // conversion failed
          lblPriceToBe.Text="Invalid Price"
          canProcess=false;
        }
        if(canProcess)
        {
        sum = Quantity * Price;
        //Output
        lblPriceToBe.Text=sum.ToString();
        }
       
    }
