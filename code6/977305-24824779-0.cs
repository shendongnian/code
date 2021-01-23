    public struct Vector4
    {
        public float Angle { get; private set; }
        public float Velocity { get; private set; }
        public Vector4 (float angle, float velocity)
        {
            // Once set in the constructor, instance values will never change.
            this.Angle = angle;
            this.Velocity = velocity;
        }
    }
