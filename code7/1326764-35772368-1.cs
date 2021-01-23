    public partial class Form1: Form
       {
          public Form2 f2 {get; set; }
          ...
       }
    
       public partial class Form2: Form
       {
          public Form1 f1 {get; set; }
          ...
       }
