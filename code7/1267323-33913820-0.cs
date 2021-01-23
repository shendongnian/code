    public MyEditor()
    {
    ...
       editor.SetBinding(Editor.TextPropety, new Binding("Text", BindingMode.TwoWay,source:this));
    
    }
