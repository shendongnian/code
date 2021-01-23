    using WindowsFormsApplicationWCF.ServiceReference1;
    
       Service1Client obj = new Service1Client();
    
       private void btnSubmit_Click(object sender, EventArgs e)
       {
           string result;
           result = obj.Calculate(Convert.ToInt32(txtPrice.Text), Convert.ToInt32(txtQty.Text));
    
            lblresult.Text = "The total price is" + result;
        }
