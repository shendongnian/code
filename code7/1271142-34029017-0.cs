        public string Name { get; set; }
        public T Value { get; set; }
    }
    
    public class SettingsDto<T> where T: struct
    {
        public List<Setting<T>> Settings { get; set; }
    }
