       private void btnsum_Click(object sender, EventArgs e) 
       {
        var n1= Convert.ToInt32(txtspm1.Text); 
        var n2= Convert.ToInt32(txtspm2.Text);
        lblsum.Text = (n1+n2).ToString(); 
       }
