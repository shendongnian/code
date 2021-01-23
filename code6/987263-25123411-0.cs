    namespace Accounting
    {
       class Account
       {
          public PersonName Name { get; set; }
          public Sexes Sex { get; set; }
          public Salutations Salutation { get; set; }
       }
    
       class PersonName
       {
          public string First { get;set; }
          public string Middle { get; set; }
          public string Last { get; set; }
       }
    
       enum Salutations : byte
       {
          Mr,
          Mrs,
          Ms,
          Miss,
          Dr,
          Hon
       }
    
       enum Sexes : byte
       {
          Male,
          Female
       }
    }
