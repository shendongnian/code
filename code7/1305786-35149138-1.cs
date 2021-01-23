    public class FilterM
    {
    public RelayCommand<IList<object>> SelectionChangedCommand  
    {
        get
        {
            if (selectionChangedCommand == null)
            {
                selectionChangedCommand = new RelayCommand<IList<object>>(
                    items =>
                    {
                        // do something with selected items!
                    }
                );
            }
    
            return selectionChangedCommand;
        }
    }
    }
