    internal class BoardEntity {
        public Vector3 Position { get; set; }
    }
    internal class Player : BoardEntity {
        public string Name { get; set; }
    }
    internal class Field : BoardEntity {
        public bool IsTarget { get; set; }
    }
