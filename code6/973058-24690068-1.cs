    //Page Load event
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostback)
        {
            //Set Control inital page load values etc in here
        }
    }
    private void resetPassword()
    {
       //You should investigate try/catch blocks to handle database errors better
       DataSet ds = new DataSet();
       myDal.ClearParams();
       myDal.AddParam("@EmailAddress", txtEmail.Text);
       myDal.AddParam("@LoginName", txtLoginName.Text);
       myDal.AddParam("@NewLoginPassword", txtNewPassword.Text);
       ds = myDal.ExecuteProcedure("spResetPassword");
       lblPasswordMessage.Text = ds.Tables[0].Rows[0]["result"].ToString();          
    }
    protected void btnSavePassword_Click(object sender, EventArgs e)
    {
        if(Page.IsValid) //The controls have already been validated now
        {
            resetPassword();
            //If you need to empty/reset fields on button click
            //do it here.
        }
            //Unless you want to reset them regarless of the validity
            //of the page. Then do it here.
    }
