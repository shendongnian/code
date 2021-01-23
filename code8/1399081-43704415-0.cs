    public class TodoItemDialog : IDialog<TodoItem>
    {
       // Somewhere, you'll call this to end the dialog
       public async Task FinishAsync(IDialogContext context, IMessageActivity activity)
       {
          var todoItem = _itemRepository.GetItemByTitle(activity.Text);
          context.Done(todoItem);
       }
    }
