     public class WindowTemplateSelector : DataTemplateSelector
      {
        public DataTemplate ViewModelTemplate1 { get; set; }
        public DataTemplate ViewModelTemplate2 { get; set; }
    
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
          if (item is ViewModel1)
            return ViewModelTemplate1;
          else
            return ViewModelTemplate2;
        }
      }
