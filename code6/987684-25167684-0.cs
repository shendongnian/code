    public static class OrderExtensions
    {
        private static IDictionary<Order,string> customErrorMessages;
        public static void SetError(this Order order, string message) {
            if (customErrorMessages == null) {
                customErrorMessages = new Dictionary<Order,string>();
            }
            if (customErrorMessages.ContainsKey(order)) {
                customErrorMessages[order] = message;
                return;
            }
            customErrorMessages.Add(order, message);
        }
        public static string GetError(this Order order) {
            if (customErrorMessages == null || !customErrorMessages.ContainsKey(order)) {
                return string.Empty;
            }
            return customErrorMessages[order];
        }
    }
