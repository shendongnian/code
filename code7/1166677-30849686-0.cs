    interface ITemplateBOption
    {
     bool TemplateBGOption{get;set;}
    }
    
    Public MyPage : Page,  ITemplateBOption
    {
     public bool TemplateBGOption 
     {
      get{...}
      set{...}
     }
    }
