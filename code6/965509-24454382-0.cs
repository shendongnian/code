    public class Model 
    {
        // Other properties
    
        private string EncryptedProperty { get; set; }
        [NotMapped]
        public string Property
        {
            get { return Decrypt(EncryptedProperty); }
            return { EncryptedProperty = Encrypt(value); }
        }
        
        public class ModelConfiguration : EntityTypeConfiguration<Model>
        {
            public ModelConfiguration() 
            {
                Property(p => p.EncryptedProperty);
            }
        }
    }
