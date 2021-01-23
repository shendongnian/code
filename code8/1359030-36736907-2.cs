    using LinqKit.Extensions;
    return tasks
          .AsExpandable()
          .Where(t => t.TaskUsers.Any(
                           x => UserAccessCheckExpression<TaskUser>(x.User).Invoke(x)
                                && x.SomeBool == true));
    
