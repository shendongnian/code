    List<SelectListItem> langResult = new List<SelectListItem>();
    
                    var result = from r in db.SURV_Language_Model
                                  select r.Language;
    
                    var result2 =   from r in db.SURV_Question_Ext_Model
                                    join s in db.SURV_Question_Model on r.Qext_Question_ID equals s.Question_ID
                                    orderby s.Question_Position ascending
                                    where r.Qext_Question_ID == Question_ID
                                    select r.Qext_Language;
    
       
                    List<string> list = new List<string>(result);
                    List<string> list2 = new List<string>(result2);
    
                    for (int x = 0; x < list.Count(); x++ )
                    {             
                        if ( x < list2.Count())
                        { 
                           if (list[0].ToString() == list2[x].ToString())
                           {
                               list.Remove(list[0].ToString());
                           }
                        }       
    
                    }
    
                    foreach (var item in list)
                    {
                        SelectListItem temp = new SelectListItem();
                        temp.Text = item;
                        temp.Value = item;
                        langResult.Add(temp);
                    }
    
                    ViewBag.LangList = langResult;
