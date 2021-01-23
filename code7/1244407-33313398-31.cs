     DataTable dt;
     protected override void Page_Load
     {
         // querying each load gets expensive; consider alternative patterns?
         dt = LoadData(txtSupportRef.Text);
         if (!IsPostBack)
         {
             int i = 0;
             ViewState["recordIndex"] = i;
             PopulateForm(i);
         }
     }
