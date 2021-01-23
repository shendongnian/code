    public class TestNode : Node
    {
        public NodeData<int> data;
        public NodeData<double> data2;
        public NodeData<double> data3;
        public TestNode()
        {
            data = new NodeData<int>("test", 111);
            data2 = new NodeData<double>("test", 113);
        }
    }
    private static void Main(string[] args)
    {
        TestNode node = new TestNode();
        var list = node.listOutputs(); // this returns data
    }
