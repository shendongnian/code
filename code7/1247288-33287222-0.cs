    public class OptionTemplateSelector : DataTemplateSelector {
       public override DataTemplate SelectTemplate(object item, DependencyObject container){
          var option = item as Option;
          if(option != null){
              var itemContainer = container as FrameworkElement;
              if(option.Value is int){
                 return itemContainer.FindResource("intOption") as DataTemplate;
              }
              else if(option.Value is string){
                 return itemContainer.FindResource("stringOption") as DataTemplate;
              }
              else if(option.Value is Brush){
                 return itemContainer.FindResource("brushOption") as DataTemplate;
              }
          }
          return null;
       }
    }
