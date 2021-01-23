    ContentControl c1 = new ContentControl();
    this.AddChild(c1);
    
    c1.ContentTemplateSelector = new TemplateSelector();
    c1.SetBinding(ContentControl.ContentProperty, new Binding());
