    public abstract class Command
        {
            private string _details;
    
            protected Command()
            {
            }
    
            protected Command(string details)
            {
                _details = details;
            }
    
            public new virtual string ToString()
            {
                return _details;
            }
    
            public virtual void FromString(string details)
            {
                _details = details;
            }
        }
    
        public class NetCommand : Command
        {
            public NetCommand(string str) : base(str)
            {
            }
        }
