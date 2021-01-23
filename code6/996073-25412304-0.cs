    <ContentControl Content="{Binding PropertyOnViewModel}" ContentTemplateSelector="{StaticResource SomeContentTemplateSelector}" />. 
    public class SomeContentTemplateSelector : DataTemplateSelector
    {
      public DataTemplate SomeTemplate {get;set;}
      protected override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        if (item is null)
          return null;
        return SomeTemplate;
      }
    }
