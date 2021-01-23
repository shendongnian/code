    if (Session["USER_ID"] != null )
                  {
                    SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=Student;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("insert into Answers (UserId, QuestionId, Answer) values (@p1, @p2, @p3)", con);
                cmd.Parameters.AddWithValue("p1", Session["USER_ID"]);
                cmd.Parameters.AddWithValue("p2", radListQ1.SelectedValue); //reference question_id field here
                cmd.Parameters.AddWithValue("p3", txtQ1Comments.Text); // reference answer field here
    
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Survey.aspx?Q=" + NextQuestionId);
            }
    
