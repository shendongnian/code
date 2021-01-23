        public class Batching
        {
            public int BatchSize { get; set; }
            public int DegreeOfParallelism { get; set; }
        }
    
        public class Settings
        {
            public int ArchivalJobCollectionPageSize { get; set; }
        }
    
        public class JobProcessor
        {
            public string JobName { get; set; }
            public bool IsEnabled { get; set; }
            public Batching Batching { get; set; }
            public Settings Settings { get; set; }
        }
    
        public class Settings2
        {
            public string LeadTimeInSeconds { get; set; }
            public int MaxSrsJobCount { get; set; }
        }
    
        public class PrimaryAction
        {
            public string ConnectionString { get; set; }
            public Settings2 Settings { get; set; }
        }
    
        public class Settings3
        {
            public string LeadTimeInSeconds { get; set; }
            public int MaxSrsJobCount { get; set; }
        }
    
        public class ErrorAction
        {
            public string ConnectionString { get; set; }
            public string EntityPath { get; set; }
            public Settings3 Settings { get; set; }
        }
    
        public class ScheduledJob
        {
            public string JobName { get; set; }
            public PrimaryAction PrimaryAction { get; set; }
            public ErrorAction ErrorAction { get; set; }
        }
    
        public class RootObject
        {
            public List<JobProcessor> JobProcessors { get; set; }
            public List<ScheduledJob> ScheduledJobs { get; set; }
        }
    
     
