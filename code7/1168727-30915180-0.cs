    class AllOptionsBackstage
    {
       public bool ShowLabelMax { get; set; }
       public bool ShowLabelMin { get; set; }
       public bool ShowLabelAvr { get; set; }
       
       public AllOptionsBackstage()
       {
          // apply default values here
       }
    }  
    .....
    class MyOptions
    {
       private AllOptionsBackstage _options;
       public MyOptions()
       { 
          Reset();  
       }
       public bool ShowLabelMax 
       {
         get{ return _options.ShowLabelMax; } 
         set{ _options.ShowLabelMax = value; }
       }
       public bool ShowLabelMin 
       {
         get{return _options.ShowLabelMin;}
         set{_options.ShowLabelMin=value; }
       }
       public bool ShowLabelAvr 
       {
         get{ return _options.ShowLabelAvr;}
         set{ _options.ShowLabelAvr = value; }
       }
       public void Reset()
       {
          _options = new AllOptionsBackstage(); // will reset all your options to default
       }
    }
