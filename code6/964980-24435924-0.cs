    ...
    public Int32 Generation
    {
        get ...
    }
    
    public class GenerationTypeSelector : DataTemplateSelector
      {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var transaction = (TransactionItem)item;
            if (transaction .Generation == 0)
                return Gen0Template;
            else
                return Gen1Template;
        }
      }
