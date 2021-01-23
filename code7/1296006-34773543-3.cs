    public class NullVisualizer : IMessageVisualizer
    {
        public void Visualize(Message m)
        {
            //Don't visualize
        }
    }
    Node node = new NodeA();
    node.MessageVisualizer = new NullVisualizer();//don't visualize
    node.DoSomethingThatMightVisualize();
