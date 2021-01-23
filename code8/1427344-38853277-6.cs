    [Serializable][DataContract][KnownType(typeof(Author))]
    [KnownType(typeof(Category))]
    [KnownType(typeof(Publisher))]
    public class Book
    {
        [DataMember]public IUniquelyIdentifiable Author { get; set; }
        [DataMember]public IUniquelyIdentifiable1 Category { get; set; }
        [DataMember]public IUniquelyIdentifiable2 Publisher { get; set; }
        [DataMember]public int BookId { get; set; }
        [DataMember]public string Title { get; set; }
        [DataMember]public string Description { get; set; }
        [DataMember]public int ISBN { get; set; }
        [DataMember]public int Price { get; set; }
        [DataMember]public string PublicationDate { get; set; }
    }
