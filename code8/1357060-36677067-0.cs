    if (!IsPostBack)
    {
       GridView1.DataSource = GetData("SELECT top 2 Question, Option1, Option2, Option3, Option4, CorrectAns, Explanation FROM Questions");
       GridView1.DataBind();
       foreach (GridViewRow row in GridView1.Rows)
       {
          if (row.RowType == DataControlRowType.DataRow)
          {
             Panel panel1 = (Panel)GridView1.FindControl("Panel1");
             Panel anspanel = (Panel)panel1.FindControl("anspanel");
             anspanel.Style.Add("display", "none");
           }
        }
     }
