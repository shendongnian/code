      [Serializable]
        public sealed class CustomBTXMessage : BTXMessage
        {
            public EESSIBTXMessage(string messageName, Context context)
                : base(messageName, context)
            {
                context.RefMessage(this);
            }
        }
