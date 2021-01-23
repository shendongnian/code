    [DataContract]
    public class LineChartData
    {
        [DataMember(Name = "x_axis")]
        public LineChartXAxis XAxis { get; set; }
    }
    [DataContract]
    public class LineChartXAxis
    {
        [DataMember(Name = "labels")]
        [XmlElement("Labels")]
        public string[] Labels { get; set; }
    }
    [DataContract]
    public class RootObject<T>
    {
        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
    public static class RootObjectExtensions
    {
        public static RootObject<T> FromData<T>(T data)
        {
            return new RootObject<T> { Data = data };
        }
    }
