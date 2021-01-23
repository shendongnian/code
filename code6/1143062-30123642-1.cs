    Public class CustomModel
    { 
       public ICollection<lang>  lstlang { get; set; }
       public ICollection<org> lstOrg { get; set; }
    }
    @HTML.textboxfor(x=>x.lang[0].id);
