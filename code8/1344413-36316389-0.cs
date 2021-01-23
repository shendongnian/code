    class Node
    {
        string name;
        Node parent;
        Node[] descendants;
        NodeValue val;
        
        ...
        
        Node Combine(Node B)
        {
            Node C = new Node();
            C.name = name;
            C.val = val.Combine(B.val);
            ...
        }
    }
    delegate NodeValue comb(NodeValue B);
    abstract class NodeValue
    {
        protected readonly int index;
        public comb[] Combinations;
        
        public NodeValue(int ind, comb[] combs)
        {
            index = ind;
            Combinations = combs;
        }
        public NodeValue Combine(NodeValue B)
        {
            if (B.index > Combinations.Length)
            {
                return null; //could alternately throw an exception, depending on the desired behavior.
            }
            return Combinations[B.index](B);
        }
    }
