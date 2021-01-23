    <!-- language: c# -->
    //Opportunity Screen
    CR304000Content CR304000 = context.CR304000GetSchema();
    context.CR304000Clear();
    //Email Activity Screen
    CR306015Content CR306015 = context.CR306015GetSchema();
    context.CR306015Clear();
    //Locate Opportunity for which Email Draft needs to be added
    CR304000Content[] CR304000result = context.CR304000Submit(
        new Command[]
        {                                        
            new Value { Value = "000007", LinkedCommand = CR304000.OpportunitySummary.OpportunityID, Commit = true},
            //Invoke New Email Actity Action
            CR304000.Actions.NewMailActivity
        });
    //Specify data for Email Activity
    CR306015Content[] CR306015result = context.CR306015Submit(
        new Command[] 
            {                    
                new Value { Value = "Subject 7", LinkedCommand = CR306015.Message.Subject },
                new Value { Value = "Notes Addition 7", LinkedCommand = CR306015.Message_.ActivityDetails},
                CR306015.Actions.Save
            });
