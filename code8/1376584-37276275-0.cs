        if ((mode == Globale.OperationMode.ADD) && (Globale.DocExist("tbl_OrderMain", "OrderNo", txtOrderNo.Text.Trim())))
            {               
              //Put a check here
               string NewNo = string.Empty;
    If(!string.IsNullOrEmpty(txtOrderNo.Text.Trim()) && txtOrderNo.Text.Trim().Length >= 6)
        {
             NewNo =  Globale.FindOrderNo(txtOrderNo.Text.Trim().Substring( 0, 6));
        }
        else
        {   
             NewNo = //Assign it to some other value. 
        }
        MessageBox.Show("Before you some body save " + txtOrderNo.Text + " now new No. is :" + NewNo, "Duplicat Doc No.");
        txtOrderNo.Text = NewNo;
    }
