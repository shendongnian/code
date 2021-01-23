    public class TrackPoint: ICloneable<TrackPoint>
    {
        public TrackPoint() { CloneId = Guid.NewGuid(); }
        public double X{get; set;}
        public double Y{get; set;}
        public Guid CloneId {get; set;}
        public TrackPoint Clone()
        {
            return new TrackPoint{ X= this.X, Y= this.Y, CloneId = this.CloneId, };
        }
    }
