    public class MyDialog : LuisDialog<string>
    {
        [LuisIntent(CategoryA.Intent1)]
        [LuisIntent(CategoryA.Intent2)]
        [LuisIntent(CategoryA.Intent3)]
        [LuisIntent(CategoryA.Intent4)]
        public async Task HandleCategoryA(IDialogContext context, LuisResult result)
        {
            var returnActivity = CategoryAHandler.Handle(result); // your business logic will be put inside this method
    
            await context.PostAsync(returnActivity);
            context.Wait(MessageReceived);
        }
        [LuisIntent(CategoryB.Intent1)]
        [LuisIntent(CategoryB.Intent2)]
        public async Task HandleCategoryB(IDialogContext context, LuisResult result)
        {
            CategoryBHandler.Handle(result); // your business logic will be put inside this method
        }
        [LuisIntent(CategoryC.Intent1)]
        public async Task HandleCategoryC(IDialogContext context, LuisResult result)
        {
            CategoryCHandler.Handle(result); // your business logic will be put inside this method
        }
    }
