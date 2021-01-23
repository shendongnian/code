    public class DataSensor
        {
            public int Id { get; set; }
            public int DataNodeId { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool active;
            public bool alarm;
            public virtual ICollection<DataSensor> Data { get; set; }
    
        }
    
        public class GatheredData
        {
            public int Id { get; set; }
            public int DataSensorId { get; set; }
            public DateTime Time { get; set; }
            public float value { get; set; }
    
            
            public virtual DataSensor datasensor { get; set; }
    
        }
