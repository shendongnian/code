    private async Task<int> ModerateCommentsAsync(IEnumerable<Comment> comments, string operation)
    {
          var commentTasks = comments.Select(comment => ModerateCommentAsync(comment, operation));
          await Task.WhenAll(commentTasks);
          return commentTasks.Count(x => x.Result);
    }
