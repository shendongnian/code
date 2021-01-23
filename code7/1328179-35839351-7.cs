    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Request.QueryString["userid"] != null && Request.QueryString["userid"] != "")
        {
            Hid_userid.Value = Request.QueryString["userid"];
            Hid_HR.Value = "Y";
            FundiableEnable();
            //DisableFormControls(Form.Controls);
            Page.ClientScript.RegisterStartupScript(this.GetType(),"TEST", "DisableAllCheckBox()",true);
        }
    }
