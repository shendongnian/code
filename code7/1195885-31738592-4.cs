    public class Item
    {
        public Guid Id;
        public String Data;
    }
    public class ItemNode : Node<ItemNode, ItemNode.Support, Guid, Item>
    {
        public class NodeSupport : BaseNodeSupport
        {
            public override Guid GetKeyFromValue(Item value) { return value.Id; }
            public override ItemNode CreateNodeFromValue(Item value) {return new ItemNode(value)
            public override ItemNode CreateHeadNode() { return new ItemNode(new Item(){Id = Guid.Empty, Data = String.Empty}); }
        }
        public ItemNode(Item item) : base(item) {}
    }
