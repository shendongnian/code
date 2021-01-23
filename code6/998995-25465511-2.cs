    internal class BoardEntity {
        public Vector3 Position { get; set; }
        public bool ComparePosition(BoardEntity boardEntity) {
            var v1 = new Vector3(boardEntity.Position.X, boardEntity.Position.Y, boardEntity.Position.Z);
            var v2 = new Vector3(Position.X, Position.Y, Position.Z);
            return v1.Equals(v2);
        }
    }
    internal class MyClass {
        public MyClass() {
            var player = new Player();
            var field = new Field();
            bool comparePosition = player.ComparePosition(field);
        }
    }
