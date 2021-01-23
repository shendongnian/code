    Survey cloneSurvey = Context.Surveys
                .Include( s => s.Questions )
                .AsNoTracking()
                .FirstOrDefault( e => e.Id == sourceId );
            Context.Surveys.Add( cloneSurvey );
            
            IEnumerable<QuestionType1> questions = cloneSurvey.Questions.OfType<QuestionType1>();
            foreach( QuestionType1question in questions )
            {
                IEnumerable<Answer> answers = Context.Answers.AsNoTracking().Where( a => a.Question.Id == question.Id );
                foreach( Answer answer in answers )
                {
                    Context.Set<Answer>().Add( answer );
                    question.Answers.Add( answer );
                }
            }
            Context.SaveChanges();
