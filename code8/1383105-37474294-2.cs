    Microsoft.VisualStudio.Text.Editor.IWpfTextView textView =
        GetTextView();
    Microsoft.VisualStudio.Text.SnapshotPoint caretPosition =
        textView.Caret.Position.BufferPosition;
    Microsoft.CodeAnalysis.Document document =
        caretPosition.Snapshot.GetOpenDocumentInCurrentContextWithChanges();
    Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax invocationExpressionNode = 
        document.GetSyntaxRootAsync().Result.
            FindToken(caretPosition).Parent.AncestorsAndSelf().
            OfType<Microsoft.CodeAnalysis.CSharp.Syntax.InvocationExpressionSyntax>().
            FirstOrDefault();
