      public class MyContentTemplateSelector : DataTemplateSelector
      {
        public DataTemplate FirstTemplate { get; set; }
        public DataTemplate SecondTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
          if (item is FirstVm)
            return FirstTemplate;
          if (item is SecondVm)
            return SecondTemplate;
          return null;
        }
      }
