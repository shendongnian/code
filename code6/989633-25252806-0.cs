    public class Load:Vector
    {
        private ForceUnit _magnitude;
        public ForceUnit Magnitude
        {
            get
            {
                    return this._magnitude;          
            }
        }
        public PointLoad(ForceUnit magnitudeOfLoad, Vector directionVector)
            : base(...)
        {
            _magnitude = magnitudeOfLoad;
        }
    }
