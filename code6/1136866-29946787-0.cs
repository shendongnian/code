    public class SelectionTemplateSelector : DataTemplateSelector
    {
    public DataTemplate Case1Template { get; set; }
    public DataTemplate Case2Template { get; set; }
    public override DataTemplate SelectTemplate(object item, 
    DependencyObject container)
    {
   
    if( //Get the binding you need)
    return Case1Template ;
    else
    return Case2Template ;
    }
    }
