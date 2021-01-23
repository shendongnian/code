    public class Customer
    {
        // ...
        public string Name { get; set; }
        
        [NotMapped]
        public string CorrectName
        {
            get { return Name.Replace('¤', 'Ñ').Replace('¥', 'ñ'); }
            set { Name = value.Replace('Ñ', '¤').Replace('ñ', '¥'); }
        }
        // ...
    }
