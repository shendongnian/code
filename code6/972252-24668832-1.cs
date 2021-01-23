     [Serializable]
    public class ControlItemConfig
    {
        public string _bColor { get; set; }
        public string _fColor { get; set; }
        public string Text { get; set; }
        
        public List<Instance> InstanceCollection { get; set; }
        public ControlItemConfig()
        {
            _bColor = string.Empty;
            _fColor = string.Empty;
            Text = string.Empty;          
        }
        class Instance
        {
            public string Name { get; set; }
        }
    }
