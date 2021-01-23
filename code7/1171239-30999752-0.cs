    public event EventHandler Saved = null;
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        UserBO userBO = new UserBO();
        userBO.Name = txtname.Text;
        userBO.address = txAddress.Text;
        userBO.EmailID = txtEmailid.Text;
        userBO.Mobilenumber = txtmobile.Text;
        UserBL userBL = new UserBL();
        userBL.SaveUserregisrationBL(userBO);
        txtEmailid.Text = null;
        txAddress.Text = null;
        txtmobile.Text = null;
        txtname.Text = null;
    
        //Check whether a control has subscribed to the Saved event
        EventHandler tmp = Saved;
        if (tmp != null) {
            //Trigger the Saved event
            tmp(this, args);
        }
    }
