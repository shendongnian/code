    public class Pupil
    {
      public Pupil()
      {
        Book = new HashSet<Book>();
        SchoolclassCodes = new HashSet<SchoolclassCode>();
      }
      public int Id { get; set; }
      public ISet<Book> Books { get; set; }
      public ISet<SchoolclassCode> SchoolclassCodes { get; set; }
    }
    public class Book
    {
      public int Id { get; set; }
      public Pupil Pupil { get; set; }
    }
    public class SchoolclassCode
    {
      public SchoolclassCode()
      {
        Pupils = new HashSet<Pupil>();
      }
      public int Id { get; set; }
      public ISet<Pupil> Pupils { get; set; }
    }
