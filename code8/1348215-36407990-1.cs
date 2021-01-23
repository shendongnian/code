    protected void Page_Load(object sender, EventArgs e)
    {
         // If it is an initial load
         if(!IsPostBack)
         {
             // Then perform your one-time data binding here
             StudentsList.DataSource = SQLStudentList;
             StudentsList.DataBind();
         }
         // Business as usual
    }
