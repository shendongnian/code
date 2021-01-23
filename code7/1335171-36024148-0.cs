    DTE2 dte = (DTE2)Package.GetGlobalService(typeof(DTE));
    TaskList tl = dte.ToolWindows.TaskList;
    dynamic commentTokens = tl.GetType().GetProperty("CommentTokens").GetValue(tl);
    
    // getting the token from the TaskList
    foreach(dynamic token in commentTokens) {
        tokens.Add(token.Text);
    }
