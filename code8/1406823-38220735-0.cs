    List<QuestionnairModel> result = new List<QuestionnairModel>(
    									model.Select(m => new QuestionnairModel()
    										{
    											Question = m.Question,
    											QuestionId = m.QuestionId,
    											QuestionnairOption = new List<QuestionnairOptionModel>(
    													m.QuestionnairOption.Select(n => new QuestionnairOptionModel()
    													{
    														OptionId = n.OptionId,
    														OptionString = n.OptionString,
    														OptionControl1 = n.OptionControl1,
    														OptionControl2 = n.OptionControl2
    													}).ToList()
    												)
    										}).ToList()
    									);
