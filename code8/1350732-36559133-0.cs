    [LuisModel("c413b2ef-382c-45bd-8ff0-f76d60e2a821", "6d0966209c6e4f6b835ce34492f3e6d9")]
    [Serializable]
    public class SimpleAlarmDialog : LuisDialog<object>
    {
        private readonly Dictionary<string, Alarm> alarmByWhat = new Dictionary<string, Alarm>();
        [Serializable]
        public class PartialMessage
        {
            public string Text { set; get; }
        }
        private PartialMessage message;
        protected override async Task MessageReceived(IDialogContext context, IAwaitable<Message> item)
        {
            var msg =  await item;
            this.message = new PartialMessage { Text = msg.Text };
            await base.MessageReceived(context, item);
        }
        [LuisIntent("builtin.intent.alarm.delete_alarm")]
        public async Task DeleteAlarm(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"echo: {message.Text}");
            Alarm alarm;
            if (TryFindAlarm(result, out alarm))
            {
                this.alarmByWhat.Remove(alarm.What);
                await context.PostAsync($"alarm {alarm} deleted");
            }
            else
            {
                await context.PostAsync("did not find alarm");
            }
            context.Wait(MessageReceived);
        }
    }
