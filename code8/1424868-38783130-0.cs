    public class YourDialog : LuisDialog<string>
    {    
        [NonSerialized]
        private IMessageActivity _originActivity;
        internal YourDialog()
        {
        }
        [LuisIntent("IntentionConstant.Empty")]
        public async Task HandleLuisResult(IDialogContext context, LuisResult result)
        {
            try
            {
                // you can access _originActivity here
            }
            catch (Exception ex) when(ex is ApplicationException)
            {
                throw;
            }
            catch (Exception ex) when (ex is TaskCanceledException)
            {
            }
        }
        protected override async Task MessageReceived(IDialogContext context, IAwaitable<IMessageActivity> item)
        {
            _originActivity = await item;
            await base.MessageReceived(context, item);
        }
    }
