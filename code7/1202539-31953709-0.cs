    public class Customer
    {
        // ...
        public string Name { get; set; }
        
        [JsonIgnore]
        [NotMapped]
        public string CorrectName
        {
            get { return Name.Replace('¤', 'Ñ').Replace('¥', 'ñ'); }
            set { Name = value.Replace('Ñ', '¤').Replace('ñ', '¥'); }
        }
        // ...
    }
