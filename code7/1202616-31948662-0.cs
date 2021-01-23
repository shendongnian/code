    [Table("Clients")]
    class Client 
    {
      [Key]
      public int Client_Id {get;set;}
      public virtual ICollection<Note> Notes {get;set;}
    }
    
    [Table("Notes")]
    class Note 
    {
      [Key]
      public int Note_Id {get;set;}
      public int Account_Id {get;set;}
      [ForeignKey("Account_Id")]
      public virtual Client Client {get;set;}
    }
