     class OptionValues
     {
          public string DisplayText {get; set;}
          public int  Value {get; set;}
          public int  CCC {get; set;}
     }
     // :
     // :
      .Select(c => new OptionValues {DisplayText = c.AAA, Value = c.BBB, CCC= c.CCC})
    
