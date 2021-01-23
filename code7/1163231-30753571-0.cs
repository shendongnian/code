    public ActionResult SURV_Main_Details_QuestionList(int Survey_ID)
            {
                List<QuestionLinkListViewModel> viewmodel = new List<QuestionLinkListViewModel>();
    
                var query = from r in db.SURV_Question_Ext_Model
                            join s in db.SURV_Question_Model on r.Qext_Question_ID equals s.Question_ID
                            where s.Question_Survey_ID == Survey_ID
                            group new { r, s } by r.Qext_Question_ID into grp
                            select grp.FirstOrDefault();
    
                foreach (var item in query.ToList())
                {
                    var queryLang = from r in db.SURV_Question_Ext_Model
                                    join s in db.SURV_Question_Model on r.Qext_Question_ID equals s.Question_ID
                                    where r.Qext_Question_ID == item.r.Qext_Question_ID
                                    select s;
    
                    if (queryLang.Count() == 1)
                    { 
                        viewmodel.Add(new QuestionLinkListViewModel()
                        {
                            Survey_ID = Survey_ID,
                            Question_ID = item.r.Qext_Question_ID,
                            QuestionText = item.r.Qext_Text,
                            Languages = item.r.Qext_Language,
                            Languages2 = " " 
                        });
                    }
                    else if(queryLang.Count() == 2)
                    {
                        viewmodel.Add(new QuestionLinkListViewModel()
                        {
                            Survey_ID = Survey_ID,
                            Question_ID = item.r.Qext_Question_ID,
                            QuestionText = item.r.Qext_Text,
                            Languages = "ENG",
                            Languages2 = "GER"
                        });
    
                    }
    
                }
    
                return PartialView(viewmodel);
            }
