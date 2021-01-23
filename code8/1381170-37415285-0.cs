    var comments = wordApp.ActiveDocument.Comments;
        foreach (Comment comment in comments)
        {
          var commentText = comment.Range.Text;
          var scopeTxt = comment.Scope.Text;
            Console.WriteLine(commentText);
        }
