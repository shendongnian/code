    class MatchNode
    {
        public short X;
        public short Y;
        private NodeVal[] myField;
		public NodeVal this[int i] { get { return myField[i]; } set { myField[i] = value; } }
        public MatchNode(int size) { this.myField = new NodeVal[size]; }
    }
