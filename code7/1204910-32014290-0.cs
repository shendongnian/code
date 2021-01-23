    class Poco
    {
         public Guid Guid { get; set; }
         
        public bool? ShouldSerialize(string fieldName)
        {
            return fieldName == "Guid" ? Guid != default(Guid) : true;
        }
    }
