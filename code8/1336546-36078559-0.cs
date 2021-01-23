    public sealed class NotificationActionBackgroundTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            var details = taskInstance.TriggerDetails as ToastNotificationActionTriggerDetail;
            if (details != null)
            {
                string arguments = details.Argument; // button argument
                var userInput = details.UserInput;
                var selection = userInput["selection"] // dropdown value
                // process button
            }
        }
    }
