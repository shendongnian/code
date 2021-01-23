    public interface IVisualizeMessageStrategy
    {
        void VisualizeMessage(Message m);
    }
    public class Node
    {
        public IVisualizeMessageStrategy VisualizeMessageStrategy ( Message m ) { get; set; }
        protected override void UserDefined_ReceiveMessageProcedure ( Message receivedMessage )
        {
            /// real implementation lies here
            ....
            /// VisualizeMessage is called in here
            this.VisualizeMessageStrategy.VisualizeMessage(receivedMessage);
        }
    }
