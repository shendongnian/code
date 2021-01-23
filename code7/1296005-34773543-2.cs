    public abstract class Node
    {
        public IMessageVisualizer MessageVisualizer { get; set; }
        protected abstract void UserDefined_ReceiveMessageProcedure(Message m);
        protected void VisualizeMessage(Message m)
        {
            MessageVisualizer.Visualize(m);
        }
    }
    public interface IMessageVisualizer
    {
        void Visualize(Message m);
    }
    public class MessageVisualizer : IMessageVisualizer
    {
        public Brush NodeColor { get; set; }
        public void Visualize(Message m)
        {
            /// visualizing the message
        }
        public bool OnIt()
        {
            /// some checks
        }
        public void Draw()
        {
            /// draw it
        }
    }
