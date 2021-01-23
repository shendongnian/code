    private bool ActionRateLimit(LogActionInput obj, string actionName, PropertyValidatorContext context)
            {
            int result = 0;
            IRecognitionStoreService StoreService = new RecognitionStoreService();
            result = StoreService.ActionRateLimit(actionName, obj.userName);            
            if (result==1)
            {
               return true;
            }
            else if (result==0)
            {
                context.MessageFormatter.AppendArgument("ValidationMessage","Invalid action name or the user doesn't exists.");
            }
            else if(result==-1)
            {
                context.MessageFormatter.AppendArgument("ValidationMessage", "Action exceeds its rate limit. Please try again in a while.");
            }
            else if (result == -3)
            {
                context.MessageFormatter.AppendArgument("ValidationMessage", "This user has not completed the prequisite challenge. Action logging failed.");
            }
            return false;
            }
        }
