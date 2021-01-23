    class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int CompareTo(Player other)
        {
            // Alphabetic sort if points are equal. [A to Z]
            if (this.Points == other.Points)
            {
                return this.Name.CompareTo(other.Name);
            }
            // Default to points sort. [High to low]
            return other.Points.CompareTo(this.Points);
        }
    }
