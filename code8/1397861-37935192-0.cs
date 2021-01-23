    public class ElementAndParamNameAttribute : Attribute
    {
      public string Element {get;set;}
      public string Param {get;set;}
    }
    .
    .
    .
    public class contact
    {
       [ElementAndParamNameAttribute(Element="lastName",Param="@lastName")]
       public string surname {get;set;}
       .
       .
       .
    }
