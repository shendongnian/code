    public class Post {
        public virtual int Id {get; set;}
        public virtual User Author {get; set;}
        public virtual LocalizableString Title {get; set;} // translatable
        public virtual LocalizableString Content {get; set;}  // translatable
    }
