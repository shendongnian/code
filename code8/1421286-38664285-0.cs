    var feedbackCount = Driver.FindElements(AuctivaSalesPageModel.ViewFeedbackSelector).Count();
    var attempts = 0;
    for(var i = 0; i < feedbackCount; i++)
    {
        while (attempts < 3)
        {
            var element = Driver.FindElements(AuctivaSalesPageModel.ViewFeedbackSelector).ElementAt(i);
            //Continue you logic here
        }
    }
