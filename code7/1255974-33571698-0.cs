    var myResults = from question in context.MyQuestions
                    where question.UserId == userId
                    from favoriteQuestion in context.MyFavoriteQuestions
                        .Where(fc => fc.UserFavoriteQuestionId == question.UserFavoriteQuestionId)
                        .DefaultIfEmpty()
                    from specialQuestion in context.Questions
                        .Where(sc => sc.QuestionId == favoriteQuestion.QuestionId)
                        .DefaultIfEmpty()
                    where specialQuestion.Id == paramId
                    where !specialQuestion.IsBlue || (specialQuestion.IsBlue && canViewBlueQuestion)
                    where !specialQuestion.IsRed || (specialQuestion.IsRed && canViewRedQuestion)
                    select question;
