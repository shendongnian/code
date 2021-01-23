        FrameworkElementFactory fef = new FrameworkElementFactory(typeof(Image));
        Binding bind = new Binding() { Path=new PropertyPath("MappingName"),Converter = new StringToImageConverter(),Mode=BindingMode.TwoWay,Source=imagecolumn };         
        fef.SetBinding(Image.SourceProperty, bind); // here you just created 
        //another instance of Binding instead  of using your bind variable
        DataTemplate template = new DataTemplate() { VisualTree = fef };            
        this.imagecolumn.CellItemTemplate = template;          
