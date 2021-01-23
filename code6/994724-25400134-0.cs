    public class ACacheableEntitySample
       : IIsReadOnly
    {
        [NotMapped]
        public bool IsReadOnly { get; set; }
        // define the "regular" entity properties
    }
