    public class CustomContextMenu 
        : ContextMenu
    {
        private bool _mustGenerateAsSeparator = false;
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
             _mustGenerateAsSeparator = (item is SeparatorMenuItem);
             return base.IsItemItsOwnContainerOverride(item);            
        }
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            if (_mustGenerateAsSeparator)
            {
                return new Separator { Style = this.FindResource(MenuItem.SeparatorStyleKey) as System.Windows.Style };
            }
            else 
            {
                return base.GetContainerForItemOverride();                      
            }            
        }
    }
