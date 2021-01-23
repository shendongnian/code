    public class General {
        public enum ProcessPriority { Low = 0, Normal = 1, High = 2 }; 
        ProcessPriority _Priority;
        [Category("Settings"), DisplayName("Application Priority")] 
        public ProcessPriority Priority {
            get { return _Priority; }
            set {
                _Priority = value;
                switch (value) {
                    case ProcessPriority.Low: 
                        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Idle;
                        break;
                    case ProcessPriority.Normal: 
                        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case ProcessPriority.High: 
                        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                        break;
                }
            }
        }
    }
