      [Serializable]
    public class ControlItemConfig
    {
        public List<Instance> InstanceCollection { get; set; }
        class Instance
        {
            public Instance()
            {
                _bColor = string.Empty;
                _fColor = string.Empty;
                Text = string.Empty;
                Name =string.Empty;
            }
            public string _bColor { get; set; }
            public string _fColor { get; set; }
            public string Text { get; set; }
            public string Name { get; set; }
        }
    }
