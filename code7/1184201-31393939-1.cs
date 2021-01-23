     public HtmlViewer()
     {
         InitializeComponent();
    
         if (!DesignerProperties.IsInDesignModeProperty) // If NOT in design mode...do work.
            populateCb();  
     }
