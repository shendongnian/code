        public class ValidationContainer
        {
            public List<UserMessage> ErrorMessages { get; set; }
            public List<UserMessage> SuccessMessages { get; set; }
            public List<UserMessage> WarningMessages { get; set; }
            public List<UserMessage> InformationMessages { get; set; }
    
            public bool HasErrors { get { return ErrorMessages.Any(); } }
            public bool HasWarnings { get { return WarningMessages.Any(); } }
            public bool HasSuccess { get { return SuccessMessages.Any(); } }
            public bool HasInformation { get { return InformationMessages.Any(); } }
            public bool IsSuccess { get { return !ErrorMessages.Any();  } }
    
            public ValidationContainer()
            {
                ErrorMessages = new List<UserMessage>();
                SuccessMessages = new List<UserMessage>();
                WarningMessages = new List<UserMessage>();
                InformationMessages = new List<UserMessage>();
    
            }
    
    
    
            public void AddMessage(MessageType messageType, string message)
            {
                var userMessage = new UserMessage
                {
                    MessageType = messageType,
                    Message = message
                };
    
                switch (messageType)
                {
                    case MessageType.Information:
                        InformationMessages.Add(userMessage);
                        break;
                    case MessageType.Success:
                        SuccessMessages.Add(userMessage);
                        break;
                    case MessageType.Error:
                        ErrorMessages.Add(userMessage);
                        break;
                    case MessageType.Warning:
                        WarningMessages.Add(userMessage);
                        break;
                }
    
            }
    }
