	[HttpPost]
    public ActionResult SURV_Answer_Submit(List<AnswerQuestionViewModel> viewmodel, int Survey_ID, string Language)
    {
        if (ModelState.IsValid)
        {
              var query = from r in db.SURV_Question_Ext_Model.ToList()
                    join s in db.SURV_Question_Model
                    on r.Qext_Question_ID equals
                    s.Question_ID
                    where  s.Question_Survey_ID == Survey_ID && r.Qext_Language == Language
                    orderby s.Question_Position ascending
                    select new { r, s };
            int i = 0;
            foreach(var item in query)
            {
                    var answer = new SURV_Answer_Model();
                    answer.Answer_Qext_ID = item.r.Qext_Question_ID;
                    string value = item.s.Question_Type;
                    string str = item.r.Qext_Configuration;
                    XElement qconfig;
                    qconfig = XElement.Parse(str);
                    XElement ChoicesType =
                    (from node in qconfig.Elements("ChoicesType")
                     select node).SingleOrDefault();
                     XDocument doc = new XDocument
                     (
                        new XDeclaration("1.0", "utf-8", "yes"),
                        new XComment("Question Configuration"),
                        new XElement("AnswerData", GetAnswerData(viewmodel, i));
					
					answer.Answer_Data = doc.ToString();
                    db.SURV_Answer_Model.Add(answer);
                    db.SaveChanges();               
            }
            return RedirectToAction("SURV_Main_Index", "SURV_Main");
        }
        return View(viewmodel);
    }
	
	public IEnumerable<XElement> GetAnswerData(List<AnswerQuestionViewModel> viewmodel, int i)
	{
		for(int x =0 ; x < viewmodel[i].MultiAnswer.Count(); x++)
		{
			yield return new XElement("Answer",viewmodel[i++].MultiAnswer[x]));
		}
	}
