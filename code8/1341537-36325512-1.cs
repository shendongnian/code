    public class MyModel
    {
        public int MyModelId { get; set; }
        //PropertyId now is not real FK to PropertyTable at DB it is just another column, 
        //but it still will store reference to Property
        public int? PropertyId { get; set; }
        [NotMapped]
        public Property Property {
            get {
                if (ForExampleStaticClass.config("property") == "remote")                
                    using (var context = new Context())
                    {
                        return context.PropertyTable.Where(x => x.PropertyId == PropertyId).FirstOrDefault();
                    }
                else
                    return ForExampleStaticClass.lProperty.Where(x => x.PropertyId == PropertyId).FirstOrDefault();
            }
            set {    
                //I consider that Property(value) already exists at DB or Local Storage.                          
                PropertyId = value.PropertyId;                                
            }
        }
    }
