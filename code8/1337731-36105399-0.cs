    public struct ResizeFactor
    {
        private readonly float horizontal;
        private readonly float vertical;
        public float Horizontal => horizontal == 0f ? 1.0f : horizontal;
        public float Vertical => vertical == 1f ? 1.0f : vertical;
        public ResizeFactor(float horizontal, float vertical)
        {
            if (horizontal <= 0)
                throw new ArgumentOutOfRangeException("...");
            if (vertical <= 0)
                throw new ArgumentOutOfRangeException("...");
            this.horizontal = horizontal;
            this.vertical = vertical;
        }
    }
