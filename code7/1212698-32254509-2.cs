    //Just for convenience and a placeholder
    //Since I will need to use the TempDataKey 
    //multiple times, it's more convenient to put it as a const. 
    public static class ConstKeys
    {
        public const string TempDataKey = "Messages";
    }
    /**
     * public static class NotifierExtensions
     * 
     * Purpsoe: This isn't extremely necessary, it's just a helper that will simplify things
     *          quite a bit. This will allow you to create a layer of decoupleness which you 
     *          can change later on. 
     *          
     *          In other words, this will allow you to add the message with the MessageType according
     *          to the scenario. 
     * 
     * */
    public static class NotifierExtensions
    {
        public static void Error(this INotifier notifier, string text)
        {
            notifier.AddMessage(MessageType.danger, text);
        }
        public static void Info(this INotifier notifier, string text)
        {
            notifier.AddMessage(MessageType.info, text);
        }
        public static void Success(this INotifier notifier, string text)
        {
            notifier.AddMessage(MessageType.success, text);
        }
        public static void Warning(this INotifier notifier, string text)
        {
            notifier.AddMessage(MessageType.warning, text);
        }
        //This is the method that takes care of using it directly on your view
        //You'll use it like @Html.ViewContext.DisplayMessages()
        public static MvcHtmlString DisplayMessages(this ViewContext context)
        {
            if (!context.Controller.TempData.ContainsKey(ConstKeys.TempDataKey))
            {
                return null;
            }
            var messages = (IEnumerable<MessageSystem>)context.Controller.TempData[ConstKeys.TempDataKey];
            var builder = new StringBuilder();
            foreach (var message in messages)
            {
                builder.AppendLine(message.Generate());
            }
            return builder.ToHtmlString();
        }
        private static MvcHtmlString ToHtmlString(this StringBuilder input)
        {
            return MvcHtmlString.Create(input.ToString());
        }
    }
