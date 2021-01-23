     protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //this portion is dynamic
            //You can get questions from your database.
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(int));
            dt.Columns.Add("Question");
            for (int i = 1; i < 10; i++)
                dt.Rows.Add(i, "Your Question -" + i);
            lstQuestions.DataSource = dt;
            lstQuestions.DataBind();
        }
    }
    protected void lstQuestions_ItemDataBound(object sender, ListViewItemEventArgs e)
    { 
        //this portion is dynamic
      //You can get answers from your database.
        RadioButtonList rdo = (RadioButtonList)e.Item.FindControl("rdoAnswers");
        DataTable dt = new DataTable();
        dt.Columns.Add("No", typeof(int));
        dt.Columns.Add("Answers");
        for (int i = 1; i < 5; i++)
            dt.Rows.Add(i, "Your Answer -" + i);
        rdo.DataSource = dt;
        rdo.DataMember = "Answers";
        rdo.DataValueField = "No";
        rdo.DataBind();
    }
