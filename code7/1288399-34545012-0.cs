    HtmlInputText twt;
    protected void Page_Load(object sender, EventArgs e)
    {
          if (!IsPostBack)
          {
               using (DB_MikaDataContext data = new DB_MikaDataContext())
               { 
                    MainFormTemplate.DataSource = data.File_Projects.Where(x => x.Num_Tik.Equals("12")).ToList();
                    MainFormTemplate.DataBind();
               }
          }
          else 
          {
               twt = MainFormTemplate.FindControl("txt_Name") as HtmlInputText;
          }           
    }
    protected void btn_Update_OnClick(object sender, EventArgs e)
    {
         string text = twt.Value; // You will get the new value
    }
