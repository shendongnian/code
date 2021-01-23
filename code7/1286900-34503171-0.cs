    class update
    {
        public static ObservableCollection<update> list_update = 
            new ObservableCollection<update>();
    
        public update(String urle)
        {
            Urle = urle;
        }
        public string Urle { get; set; }
        public override string ToString()
        {
            return Urle;
        }
    }
