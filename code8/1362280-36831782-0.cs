        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {  
            instructrid = Int32.Parse(Session["instructorId"].ToString());
            ((TextBox)Login1.FindControl("userName")).Text = Session["firstname"].ToString();
            ((TextBox)Login1.FindControl("password")).Text = Session["surname"].ToString();
            ((TextBox)Login1.FindControl("gender")).Text = Session["gender"].ToString();
            ((TextBox)Login1.FindControl("email")).Text = Session["email"].ToString();
            ((TextBox)Login1.FindControl("style")).Text = Session["style"].ToString();
            ((TextBox)Login1.FindControl("phonenumber")).Text = Session["phonenumber"].ToString();
            ((TextBox)Login1.FindControl("hourlyRate")).Text = Session["hourlyRate"].ToString();
            ((TextBox)Login1.FindControl("availability")).Text = Session["availability"].ToString();
           }
       }
 
