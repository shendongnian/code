    List<AuditResultSelectList> list = new List<AuditResultSelectList>();
        
    foreach (var r in employeeAuditData.Audit.AuditResults)
    {
        AuditResultSelectList a = new AuditResultSelectList()
        {
            QuestionId = r.AuditQuestionID,
            QuestionOptions = new SelectList(r.AuditQuestion.QuestionOptions, "QuestionOptionID", "OptionText", r.QuestionOption)
        }
        list.Add(a);
    }
    ViewData["QuestionSelectLists"] = list;
