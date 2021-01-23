    [TemplatePart(Name = "myButton", Type = typeof(Button))]
    public class MyStylizedGrid : RadGridView
    {
    Button _btn;
    // here the constructor and other methods you're using
   
    //Then you use the OnApplyTemplate method to get that component you need 
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        _btn = GetTemplateChild("myButton") as Button;
    }
    
    }
