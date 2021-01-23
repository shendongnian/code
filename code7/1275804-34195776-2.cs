                //To bound the questions
                rptQuestionsEng.DataSource = _survey.Questions;
                rptQuestionsEng.DataBind();
                //To bound the choices
                protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
                {
                  if (e.Item.ItemType == ListItemType.Item ||
                   e.Item.ItemType == ListItemType.AlternatingItem)
                  {
                     if (rblLanguage.SelectedValue.Equals("1"))
                     {
                        foreach (Question q in _survey.Questions)
                        {
                          q.answers = _blSurvey.GetAnswers(q.TypeOfQuestion);
                          var rbl = (RadioButtonList)e.Item.FindControl("rblQuestionEng");
                          if (!string.IsNullOrEmpty(q.QuestionEng))
                          {
                            rbl.DataTextField = "AnswerEng";
                            rbl.DataValueField = "AnswerId";
                            rbl.DataSource = q.answers;
                            rbl.DataBind();
                          }
                        }
                      }
                    }
                  }
                
