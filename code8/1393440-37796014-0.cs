    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            Master.PageTitle(PageTitles.UpdateAdd);
            NameValueCollection nvc = Request.Form;
            if (nvc.Count == 2 && nvc["ThisIsAnUpdate"] == "1")
            {
                // Ladies and gentlemen, we have an update. Do the work.
                ThisIsAnUpdate.Value = "1";
                DetailedAddressEntity myCustomer = new RetreiveInformation().FetchDetailedInformation(nvc["ID"]);
                SetupEdit(myCustomer);
            }
        }
    }
