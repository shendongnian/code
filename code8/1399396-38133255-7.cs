    public async Task CheckResponseAsync(IDialogContext context, IAwaitable<Answer> argument)
        {
            Answer answer = await argument;
            if (answer.AnswerText.StartsWith(jokerAnswerText))
            {
                jokerCount--;
                await context.PostAsync("Suppression de deux mauvaises réponses...");
                DisplayQuestion(context, true);
            }
            else
            { 
                await context.PostAsync(answer.IsCorrect ? "Bonne réponse !" : "Mauvaise réponse !");
                index++;
                Answer goodAnswer = theQuestion.Answers.First(a => a.IsCorrect);
                if (answer.AnswerText == goodAnswer.AnswerText)
                {
                    Score++;
                }
                if (index < problems.Count)
                {
                    DisplayQuestion(context);
                }
                else
                {
                    await context.PostAsync($"Votre score est de {Score}");
                    context.Done(Score);
                }
            }
        }
