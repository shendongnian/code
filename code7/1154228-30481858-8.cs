        public interface IRuntimeData
        {
         string filePath { get; set; }
         string connectionString { get; set; }
         string machineName { get; set; }
        }
        
        class RuntimeData : IRuntimeData
        {
         public string filePath { get; set; }
         public string connectionString { get; set; }
         public string machineName { get; set; }
        }
    
