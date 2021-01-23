    class Batch
    {
     public int BatchId { get; set; }
     public string BachFirstName{ get; set; }
     public string BachLastName{ get; set; }
     public string BachGender{ get; set; }
     public Document BachDocument{ get; set; }
    }
    class Document
    {
     public int DocId { get; set; }
     public string DocDesignation{ get; set; }
     public State DocState{ get; set; }
    }
    class State
    {
     public int Id { get; set; }
     public string StateDesignation{ get; set; }
     public date StateDate{ get; set; }
    }
