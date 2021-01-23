    private void DisplayQuestion(IDialogContext context)
        {
            DisplayQuestion(context, false);
        }
        private void DisplayQuestion(IDialogContext context, bool useJoker)
        {
            theQuestion = problems[index];
            string questionText = theQuestion.QuestionText;
            IList<Answer> answers = theQuestion.Answers.ToList();
            if (useJoker)
            {
                IList<Answer> randomBadAnswers = answers.Where(a => !a.IsCorrect).ToList();
                randomBadAnswers.Shuffle();
                randomBadAnswers = randomBadAnswers.Take(2).ToList();
                answers = answers.Except(randomBadAnswers).ToList();
            }
            else if (jokerCount > 0)
            {
                Answer jokerAnswer = new Answer
                {
                    AnswerText = $"{jokerAnswerText} ({jokerCount}) restant(s)"
                };
                answers.Add(jokerAnswer);  
            }
            PromptDialog.Choice(context, CheckResponseAsync, answers, questionText, null, 0, PromptStyle.Auto);
        }
