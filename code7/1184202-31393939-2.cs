     public HtmlViewer()
     {
         InitializeComponent();
    
         if (!DesignerProperties.GetIsInDesignMode(this)) // If NOT in design mode...do work.
            populateCb();  
     }
