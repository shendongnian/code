    public class ProgressChgEventArgs : System.EventArgs
    {
        public string Name { get;set; }
        public int InstanceId { get;set; }
        public ProgressChgEventArgs(string name, int id)
        {
            Name = name;
            InstanceId = id;
        }
    }
