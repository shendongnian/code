    public class Tile
    {
        public readonly int ProducerId { get; set; }
        public readonly int Level { get; set; }
        public Tuple<int, Tuple<int, int>> Id { get; set; }
        public Tuple<int, Tuple<int, int>> TId { get; set; }
    }
