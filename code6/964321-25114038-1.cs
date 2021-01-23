      [Serializable]
        public sealed class CustomBTXMessage : BTXMessage
        {
            public CustomBTXMessage(string messageName, Context context)
                : base(messageName, context)
            {
                context.RefMessage(this);
            }
        }
