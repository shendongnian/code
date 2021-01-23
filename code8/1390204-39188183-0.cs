    private int questionNumber;
    private Offering offering;
    
    private async Task CreateOffering(IDialogContext context, IAwaitable<Offering> result)
    {
        offering = await result;
        await context.PostAsync($"***CREATING {offering.Name.ToUpper()}***");
        questionNumber = 0;
        // fix access to a particular question in case Questions is not an IList
        PromptDialog.Text(context, OnQuestionReply, offering.Questions[questionNumber].Question);
    }
    
    private async Task OnQuestionReply(IDialogContext context, IAwaitable<string> result)
    {
        var answer = await result;
        // handle the answer for questionNumber as you need
    
        questionNumber++;
        // use Count instead of Length in case it is not an array
        if (questionNumber < offering.Questions.Length)
        {
            PromptDialog.Text(context, OnQuestionReply, offering.Questions[questionNumber].Question);
        }
        else
        {
            // do what you need when all the questions are answered
            await context.PostAsync("I have no more questions for this offering.");
            context.Wait(MessageReceived);
        }
    }
