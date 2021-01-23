        public class ObsceneNode
    {
        public ObsceneNode(ObsceneValue value)
        {
            Value = value;
            Children = new Dictionary<char, ObsceneNode>();
        }
        public ObsceneValue Value { get; set; }
        public Dictionary<char, ObsceneNode> Children { get; set; }
        public bool HasChild(char character)
        {
            return Children.ContainsKey(character);
        }
        public ObsceneNode SafeAddChild(ObsceneValue value)
        {
            if (HasChild(value.Character))
            {
                return GetChild(value.Character);
            }
            var node = new ObsceneNode(value);
            Children.Add(value.Character, node);
            return node;
        }
        public ObsceneNode GetChild(char character)
        {
            if (HasChild(character))
            {
                return Children[character];
            }
            return null;
        }
    }
