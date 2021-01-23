    public class ProcessContainer
            {
                public string ProcessName {get;set;}
                public int Memory { get; set; }
    
                public ProcessContainer(string name, int memory)
                {
                    ProcessName = name;
                    Memory = memory;
                }
            }
