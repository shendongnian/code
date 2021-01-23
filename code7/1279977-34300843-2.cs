    public class ImageDto : IDtoCommon
    {
         public ObjectId Id {get; set;}
         public int PosLeft {get; set;}
         public int PosTop {get; set;}
         public ICollection<string> PropertyImage1 {get; set;}
         public string PropertyImage2 {get; set;}
    }
    public class TextDto : IDtoCommon
    {
         public ObjectId Id {get; set;}
         public int PosLeft {get; set;}
         public int PosTop {get; set;}
         public double PropertyText1 {get; set;}
         public string PropertyText2 {get; set;}
    }
    public class Image : Entity, IEntityCommon
    {
        public ObjectId Id { get; set; }
        public int PosLeft { get; set; }
        public int PosTop { get; set; }
        public ICollection<string> PropertyImage1 { get; set; }
        public string PropertyImage2 { get; set; }
        public string OtherPropertyImage { get; set; }
    }
    public class Text : Entity, IEntityCommon
    {
        public ObjectId Id { get; set; }
        public int PosLeft { get; set; }
        public int PosTop { get; set; }
        public double PropertyText1 { get; set; }
        public string PropertyText2 { get; set; }
        public string OtherPropertyText { get; set; }
    }
