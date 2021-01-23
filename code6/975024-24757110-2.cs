    public class Person
    {
      public virtual string Name{get;set;}
      public virtual int Id{get;set;}
      //public virtual char Gender{get;set;} #this one I want to connect
      public virtual Gender Gedner { get; set; }
    }
