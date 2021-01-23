       public List<Question> GetQuestions(string xmlFile)
        {
            var questions = new List<Question>();
            var xDoc = XDocument.Load(xmlFile);
            var questionNodes = xDoc.Descendants("theQuestion");
            foreach (var questionNode in questionNodes)
            {
                var question = new Question();
                question.QuestionText = questionNode.Value;
                // do something like this for all the answers
                var answer = new Answer();
                answer.ID = "A";
                var answerA = questionNode.Descendants("answerA").FirstOrDefault();
                if (answerA != null)
                    answer.AnswerText = answerA.Value;
                question.Answers = new List<Answer>();
                question.Answers.Add(answer);
                question.AnswerText =
                    questionNode.Descendants("correctAnswer").FirstOrDefault().Value;
            }
            return questions;
        } 
    }
