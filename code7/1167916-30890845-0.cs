    Sub NewCommentLinePersonal()
        Dim textSelection As EnvDTE.TextSelection
 
        textSelection = DTE.ActiveWindow.Selection
        textSelection.NewLine()
        textSelection.Insert(Utilities.LineOrientedCommentStart())
        textSelection.Insert(" **NAME**, " + Date.Now.ToShortDateString + ":")
    End Sub
 
    Sub NewCommentLineTodoPersonal()
        Dim textSelection As EnvDTE.TextSelection
 
        textSelection = DTE.ActiveWindow.Selection
        textSelection.NewLine()
        textSelection.Insert(Utilities.LineOrientedCommentStart())
        textSelection.Insert(" TODO: **NAME**, " + Date.Now.ToShortDateString + ":")
    End Sub
 
