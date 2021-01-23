    abstract class Command<T>
    {
        public abstract T GetValue();
    }
    
    class TalkCommand : Command<string>
    {
        public override string GetValue()
        {
            return "Test";
        }
    }
    
    // TalkCommand isn't Command<object>
    Command<object> cmd = new TalkCommand();
