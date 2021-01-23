    public class Categorey : EntityString
    {
       
        public string Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
       private string descriptions = string.Empty;
        public ListObservableCollection<string> AllowedDescriptions
        {
            get
            {
                return Getter(ref descriptions);
            }
            set
            {
                Setter(ref descriptions, ref value);
            }
        }
        
        public DateTime Date { get; set; }
    }
