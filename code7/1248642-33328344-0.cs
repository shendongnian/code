    try {
        decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
        try {
            if(x<0 || x>10000){
                throw new OverFlowException("");
            }
            //Do what ever you want
        }
        catch(Exception ex){
            // catch overflow
        }
    }
    catch(Exception ex){
        // catch nonnumeric value
    }
