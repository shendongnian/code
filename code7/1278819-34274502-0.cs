    public struct DSpeed 
    {
        public double Angle { get; private set; }
        public double Speed { get; private set; }
        public double XSpeed { get; private set; }
        public double YSpeed { get; private set; }
        private DSpeed(double angle, double speed, double xspeed, double yspeed)
        {
            Angle = angle;
            Speed = speed;
            XSpeed = xspeed;
            YSpeed = yspeed;
        }
        public static DSpeed FromAngle(double angle, double speed) 
        {
            var xspeed = Math.Sin(angle) * speed;
            var yspeed = Math.Cos(angle) * speed;
            return new DSpeed(angle, speed, xspeed, yspeed);
        }
        public static DSpeed FromXY(double xspeed, double yspeed)
        {
            DPoint p1 = new DPoint(0, 0);
            DPoint p2 = new DPoint(xspeed, yspeed);
            var speed = p1.GetDistance(p2);
            var angle = Math.Atan2(xspeed, yspeed);
            return new DSpeed(angle, speed, xspeed, yspeed);
        }
    }
