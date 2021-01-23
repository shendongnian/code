    public class OvalShapeBullet
    {
        private readonly OvalShape _ovalShape;
        private Point _location;
        private readonly double _angle;
        private double _distance;
        public OvalShapeBullet(Point orgin, Point target, OvalShape ovalShape)
        {
            _ovalShape = ovalShape;
            _location = new Point(orgin.X - ((int)ovalShape.Width / 2), orgin.Y - ((int)ovalShape.Height / 2));
            _distance = Math.Sqrt((orgin.X - target.X) ^ 2 + (orgin.Y - target.Y) ^ 2);
            _angle = Math.Atan2(target.Y, target.X);
        }
        public Point Location { get { return _location; } }
        public bool Visible
        {
            get { return _ovalShape.Visible; }
            set { _ovalShape.Visible = value; }
        }
        /// <summary>
        /// Attempts to move bullet to target
        /// </summary>
        /// <param name="distance">The distance the bullt will travel</param>
        /// <returns>True if bullet connects with target</returns>
        public bool TryMoveToTarget(float distance)
        {
            if (_distance <= 0)
                return true;        // check if bullet has travelled far enough
            _location.X += (int)(distance * Math.Cos(_angle));
            _location.Y += (int)(distance * Math.Sin(_angle));
            _distance -= distance;
            return _distance <= 0;  // check if bullet has traveled far enough
        }
    }
