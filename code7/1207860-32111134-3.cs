    List<SurveyForm> forms = new List<SurveyForm>();
    List<SurveyAnswer> answers = new List<SurveyAnswer>();
    foreach (int teamMemberId in teamMemberIds)
    {
        var employee = employees.First(x => x.Id == teamMemberId);
        SurveyForm form = new SurveyForm();
        //some code
        forms.Add(form);
        foreach (int peer in teamMemberIds)
        {
             foreach (SurveySectionDetail SectionDetail in sectionDetails)
             {
                  foreach (SurveyAttributeDetail AttributeDetail in 
                             attributeDetailsGroupBySection[SectionDetail.Id])
                  {
                       SurveyAnswer answer = new SurveyAnswer();
                       //some code
                       answers.Add(answer);
                  }
             }
        }
    }
    db.SurveyAnswers.AddRange(answers);
    db.SurveyForms.AddRange(forms);
    db.SaveChanges();
