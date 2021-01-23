       public interface IPublication
    {
        Person[] Author { get; set; }
        string title { get; set; }
        string[] AuthorReferenceID { get; }
    }
