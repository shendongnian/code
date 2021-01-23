    internal class BoardEntity {
        public Vector3 Position { get; set; }
        protected bool Equals(BoardEntity other) {
            return Position.Equals(other.Position);
        }
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as BoardEntity;
            return other != null && Equals(other);
        }
        public override int GetHashCode() {
            return Position.GetHashCode();
        }
    }
    internal class MyClass {
        public MyClass() {
            var player = new Player();
            var field = new Field();
            BoardEntity boardEntity1 = player;
            BoardEntity boardEntity2 = field;
            bool b = boardEntity1.Equals(boardEntity2);
        }
    }
