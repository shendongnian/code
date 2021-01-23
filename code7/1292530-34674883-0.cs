    I wantto Authors save.
    
    //this Domain
     public class Manuscript 
    {
        public int Id { get; set; }
        public string ArchiveNumber { get; set; }
    
        [XmlIgnore]
        public virtual ICollection<ManuscriptAuthor> Authors { get; set; }
    }
    
      public class ManuscriptAuthor
        {
            public int ManuscriptId { get; set; }
    
            public int AuthorId { get; set; }
        }
    
    //this controller
     public ActionResult Edit(ViewModelEdit viewModelEdit)
     {
         Manuscript manuscript = null;
         manuscript.Authors = viewModelEdit.Entity.Authors; // this  error
     }
