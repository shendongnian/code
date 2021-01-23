    public class Partner
    {
       public PartnersGroup PartnersGroup { get; set; }
       [doNotGenerateIntoDatabase]
       public string PartnersGroupString { 
      get{ 
            return  
                   Strings.ResourceManager.GetString("PartnersGroup_" + this.PartnersGroup);}
       }
    
    }
