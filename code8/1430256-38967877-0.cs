    public class CustomCell: TextCell
    {
            public CustomCell(Page page)
            {
                var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true }; // red background
                deleteAction.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                deleteButton.SetBinding (MenuItem.CommandProperty, new Binding ("BindingContext.DeleteCommand", source: page));
                ContextActions.Add(deleteAction);
            }
    }
