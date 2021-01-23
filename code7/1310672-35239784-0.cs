    public class CareTaker
    {
        ...
        [NotMapped]
        [JsonProperty(PropertyName = "certification"]
        public int? CertificationId
        {
            get
            {
                 return Certification?.Id;
            }
            set
            {
               Certification = new Certification { Id = value; }
            }
        }
        [JsonIgnore]
        public Certification Certification {get; set;}
        ...
    }
