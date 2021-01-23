    protected void btnsave_Click(object sender, EventArgs e)
    {
    	using (DataClasses1DataContext sdc = new DataClasses1DataContext()) 
        {      
    		string fileName = FileUpload1.FileName;
    		byte[] fileByte = FileUpload1.FileBytes;
    		Binary binaryObj = new Binary(fileByte);
    		Professor_Dim prof = sdc.Professor_Dims.SingleOrDefault(x => x.P_ID == 0);
    
    		if (  !string.IsNullOrEmpty(txtfirstname.Text))
    			prof.P_Fname = txtfirstname.Text;
    
    		if (  !string.IsNullOrEmpty(txtlastname.Text))
    			prof.P_Lname = txtlastname.Text;
    
    		if (  !string.IsNullOrEmpty(txtemail.Text))
    			prof.P_Email = txtemail.Text;
    
    		if (  !string.IsNullOrEmpty(txtaddress.Text))
    			prof.P_Address = txtaddress.Text;
    
    		if (  !string.IsNullOrEmpty(txtphone.Text))
    			prof.P_Phone = txtphone.Text;
    
    		prof.P_Image = binaryObj;
    		sdc.SubmitChanges();
    	}
    } 
