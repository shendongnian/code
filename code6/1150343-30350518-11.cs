    [DataContract(Name = "Point", Namespace = "myContract.com/dto")]
    public class Point : Geometry
    {
        [DataMember(Name = "x",Order = 1)]
        public double X { get; set; }
        [DataMember(Name = "y", Order = 2)]
        public double Y { get; set; }
    }
    [DataContract(Name = "Line", Namespace = "myContract.com/dto")]
    public class Line : Geometry
    {
        [DataMember(Name = "start", Order = 1)]
        public Point Start { get; set; }
        [DataMember(Name = "end", Order = 2)]
        public Point End { get; set; }
    }
