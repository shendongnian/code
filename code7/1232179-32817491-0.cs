     protected void Page_Load(object sender, EventArgs e)
     {
         if(!IsPostBack)
         { 
                //Populate The Select Tag with Subjects
                SubjectList.DataSource = Session["TeacherSubjectList"];
                SubjectList.DataTextField = "CourseNo";
                SubjectList.DataValueField = "CourseNo";
                SubjectList.DataBind();
         }
      }
