    MsCustomer mc = new MsCustomer
    {
         /* new line */
         CustomerID = generateID();
         CustomerName=nameBox.Text,
         CustomerGender=gender,
         CustomerPhone=phoneBox.Text,
         CustomerAddress=addressBox.Text
    };
    dc.MsCustomers.InsertOnSubmit(mc);
    dc.SubmitChanges();                
    
    MessageBox.Show("Insert Success");
    
