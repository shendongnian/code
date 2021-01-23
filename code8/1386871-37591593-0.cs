    public abstract class CallDecorator : Call
    {
        public CallDecorator(Call aCall):base(aCall.Conversation)
        {
    
        }
    }
