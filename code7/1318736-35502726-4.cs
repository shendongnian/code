    public class ValidationContainer
    {
        public List<string> ErrorMessages { get; set; }
        public List<string> SuccessMessages { get; set; }
        public List<string> WarningMessages { get; set; }
        public List<string> InformationMessages { get; set; }
        public void AddMessage(MessageType messageType, string message)
        {
            switch (messageType)
            {
                case MessageType.Information:
                    InformationMessages.Add(message);
                    break;
                case MessageType.Success:
                    SuccessMessages.Add(message);
                    break;
                case MessageType.Error:
                    ErrorMessages.Add(message);
                    break;
                case MessageType.Warning:
                    WarningMessages.Add(message);
                    break;
            }
        }
    }
    public enum MessageType
    {
        Error = 1,
        Success = 2,
        Warning = 3,
        Information = 4,
        Debug = 5,
    }
