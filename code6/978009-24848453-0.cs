     public class ProcessContainer
        {
            private string process;
    
            public string ProcessName
            {
                get { return process; }
                set { process = value; }
            }
    
            private int memory;
    
            public int Memory
            {
                get { return memory; }
                set { memory = value; }
            }
    
    
            public ProcessContainer(string name, int memory)
            {
                ProcessName = name;
                Memory = memory;
            }
        }
