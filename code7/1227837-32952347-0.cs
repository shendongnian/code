    public class EventBase
    {
        public string HardwareId { get;set; }
        public DateTime MessageGeneratedTime { get; set; }
        public DateTime MessageReceivedTime { get; set; }
        public DateTime MessageAdaptedTime { get; set; }
        public override string ToString()
        {
            return string.Format("{0} event - HardwareId: {1}, CreateTime: {2}, MessageReceivedTime: {3}", GetType(), HardwareId, MessageGeneratedTime, MessageReceivedTime);
        }
        public T Default<T>(string dardwareId, DateTime createTime, DateTime receiveTime) where T : TestBase, new()
        {
            var instance = new T
            {
                HardwareId = hardwareId,
                MessageGeneratedTime = createTime,
                MessageReceivedTime = receiveTime,
                MessageAdaptedTime = DateTime.UtcNow
            };
            return instance;
        }
    }
