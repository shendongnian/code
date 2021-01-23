    [Serializable]
    public class Trajectory : SortedSet<PolarPosition>
    {
        protected override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Name", this.Name);
            info.AddValue("UsedCoordinateSystem", (int)this.UsedCoordinateSystem);
        }
        public Trajectory(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Name = info.GetString("Name");
            this.UsedCoordinateSystem = (CoordinateSystemEnum)info.GetInt32("UsedCoordinateSystem");
        }
    }
