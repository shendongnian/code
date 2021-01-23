    [Serializable, LuisModel("[ModelID]", "[SubscriptionKey]")]
    public class TodoItemDialog : LuisDialog<TodoItem>
    {
        [LuisIntent("GetTodoItem")]
        public async Task GetTodoItem(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Working on it, give me a moment...");
            result.TryFindEntity("TodoItemText", out EntityRecommendation entity);
            if(entity.Score > 0.9)
            {
                var todoItem = _todoItemRepository.GetByText(entity.Entity);
                context.Done(todoItem);
            }
        }
    }
