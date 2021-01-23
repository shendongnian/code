    MasterValue oMV = new MasterValue();
    DataTable dt = oMV.GetAll(MasterValueType.ContactMethod);
    //Now you assign specific field name and field id like below
    cboContact.DataSource = dt;
    cboContact.DataTextField = "strText";
    cboContact.DataValueField = "intID";
    cboContact.DataBind();
