     private void PopulateContactMethod(int intContactMethodID)
    {
        // get data
        MasterValue oMV = new MasterValue();
        DataTable dt = oMV.GetAll(MasterValueType.ContactMethod);
        // populate combo
        cboContact.SelectedIndex = 4;
         (or)  // By setting the Value
        cboContact.SelectedValue = "None";
        cboContact.Bind();
    }
      
