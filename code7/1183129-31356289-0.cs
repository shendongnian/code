    int questionId = 1;
    var questionAnswers = list.Where(elem => elem.PoolQID == questionId);
    int questionAnswersCount = questionAnswers.Count();
	var anweresPrecentage = questionAnswers
							.GroupBy(elem => elem.PoolAID)
							.ToDictionary(grp => grp.Key, grp => (grp.Count() * 100.0 / questionAnswersCount));
